using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Numerics;

namespace NuedcCompTestAutoScoring
{
    using GwScpiRwFun = Func<byte[], int, int, int>;

    internal class GwScpiEth
    {
        private const int timeOut = 1000;
        public GwScpi Scpi;
        private Socket soc;
        public GwScpiEth(string ip, string port, int rxBufSize = 65536)
        {
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soc.ReceiveTimeout = timeOut;
            soc.SendTimeout = timeOut;

            IAsyncResult result = soc.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), int.Parse(port)), null, null);

            bool success = result.AsyncWaitHandle.WaitOne(timeOut, true);

            if (soc.Connected)
            {
                Scpi = new(
                    (byte[] tx, int o, int l) => soc.Send(tx, o, l, SocketFlags.None),
                    (byte[] rx, int o, int l) => soc.Receive(rx, o, l, SocketFlags.None),
                    rxBufSize
                    );
            }
            else
            {
                soc.Close();
                throw new TimeoutException();
            }
        }
        public void Close()
        {
            soc.Close();
        }
    }
    internal class GwScpi
    {
        private GwScpiRwFun wfun;
        private GwScpiRwFun rfun;
        //private byte[] txbuf;
        private byte[] rxbuf;
        public int AcqMemCh = 1;
        private void write(byte[] data, int len)
        {
            for (int i = 0; i < len;)
            {
                i += wfun(data, i, len);
            }
        }
        private void read(byte[] data, int len)
        {
            for(int i = 0; i < len; )
            {
                i += rfun(data, i, len);
            }
        }
        public GwScpi(GwScpiRwFun write, GwScpiRwFun read, /*int txBufSize = 256,*/ int rxBufSize = 65536)
        {
            this.wfun = write;
            this.rfun = read;
            //txbuf = new byte[txBufSize];
            rxbuf = new byte[rxBufSize];
        }
        public void Flush()
        {
            int l = rfun(rxbuf,0, rxbuf.Length);
        }
        public string Command(string cmd, bool hasRtn = true)
        {
            byte[] txdata = Encoding.ASCII.GetBytes(cmd + "\n");
            write(txdata, txdata.Length);
            if (hasRtn)
            {
                int len = rfun(rxbuf, 0, 8192);
                string str = Encoding.ASCII.GetString(rxbuf, 0, len);
                if (str[str.Length - 1] == '\n')
                    return str.Substring(0, str.Length - 1);
                else
                    return str;
            }
            else
            {
                return "";
            }
        }
        public int AcquireMemory(short[] rawData)
        {
            string rtn = Command(@":ACQuire" + AcqMemCh.ToString() + @":MEMory?");
            int sharp = rtn.IndexOf('#');
            int l = int.Parse(rtn.Substring(sharp + 1, 1));
            l = int.Parse(rtn.Substring(sharp + 2, l));
            this.read(rxbuf, l + 1);    // include '\n'
            //soc.Receive(rxbuf, 1, SocketFlags.None);
            for (int i = 0; i < l; i += 2)
            {
                Array.Reverse(rxbuf, i, 2);
            }
            Buffer.BlockCopy(rxbuf, 0, rawData, 0, l);
            //int l2 = rfun(rxbuf, 0, 8192);
            return l / 2;
        }
        public void MeasureSource(int ch)
        {
            this.Command(@":MEASure:SOURce1 CH" + ch.ToString(), false);
        }
        public void MeasureSource(int ch1, int ch2)
        {
            this.Command(@":MEASure:SOURce1 CH" + ch1.ToString(), false);
            this.Command(@":MEASure:SOURce2 CH" + ch2.ToString(), false);
        }
        public double MeasureAmplitude()
        {
            string val = this.Command(@":MEASure:AMPlitude?");
            return double.Parse(val);
        }
        public double MeasurePeak2Peak()
        {
            string val = this.Command(@":MEASure:PK2Pk?");
            return double.Parse(val);
        }
        public double MeasureRms()
        {
            string val = this.Command(@":MEASure:RMS?");
            return double.Parse(val);
        }
        public double MeasurePeriod()
        {
            string val = this.Command(@":MEASure:PERiod?");
            return double.Parse(val);
        }
        public double MeasureRise()
        {
            string val = this.Command(@":MEASure:RISe?");
            return double.Parse(val);
        }
        public double MeasureFall()
        {
            string val = this.Command(@":MEASure:FALL?");
            return double.Parse(val);
        }
        public void VeticalSetting(int ch, bool ac, double pos, double scale)
        {
            if(ac)
                this.Command(@":CHANnel" + ch.ToString() + ":COUPling AC");
            else
                this.Command(@":CHANnel" + ch.ToString() + ":COUPling DC");
            this.Command(@":CHANnel" + ch.ToString() + ":POSition " + pos.ToString());
            this.Command(@":CHANnel" + ch.ToString() + ":SCAle " + pos.ToString());
        }
        public void ParseAndSetFromString(int ch, string str)
        {
            if (str == null)
                return;
            int len = str.Length;
            for (int i = 0, j = 0; i < len && j >= 0; i = j + 1)
            {
                int k;
                j = str.IndexOf(",", i);
                string word;
                if (j > 0)
                {
                    word = str.Substring(i, j - i);
                }
                else
                {
                    word = str.Substring(i, len - i);
                }
                if (word.Contains("DC", StringComparison.OrdinalIgnoreCase))
                {
                    this.Command(@":CHANnel" + ch.ToString() + ":COUPling DC", false);
                }
                else if (word.Contains("AC", StringComparison.OrdinalIgnoreCase))
                {
                    this.Command(@":CHANnel" + ch.ToString() + ":COUPling AC", false);
                }
                else if ((k = word.IndexOf("V/div", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(0, k);
                    double d = val.ToDoubleFromEngineerFormat();
                    d = Math.Round(d, 6);
                    this.Command(@":CHANnel" + ch.ToString() + ":SCAle " + d.ToString(), false);
                }
                else if ((k = word.IndexOf("Vpos", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(0, k);
                    double d = val.ToDoubleFromEngineerFormat();
                    d = Math.Round(d, 6);
                    this.Command(@":CHANnel" + ch.ToString() + ":POSition " + d.ToString(), false);
                }
                else if ((k = word.IndexOf("s/div", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(0, k);
                    double d = val.ToDoubleFromEngineerFormat();
                    d = Math.Round(d, 10);
                    this.Command(@":TIMebase:SCALe " + d.ToString(), false);
                }
                else if ((k = word.IndexOf("spos", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(0, k);
                    double d = val.ToDoubleFromEngineerFormat();
                    d = Math.Round(d, 10);
                    this.Command(@":TIMebase:POSition " + d.ToString(), false);
                }
                else if ((k = word.IndexOf("Vtrigr", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(0, k);
                    this.Command(@":TRIGger:TYPe EDGE", false);
                    this.Command(@":TRIGger:EDGe:SLOP RISe", false);
                    this.Command(@":TRIGger:LEVel " + val.ToDoubleFromEngineerFormat(), false);
                }
                else if ((k = word.IndexOf("Vtrigf", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(0, k);
                    this.Command(@":TRIGger:TYPe EDGE", false);
                    this.Command(@":TRIGger:EDGe:SLOP FALL", false);
                    this.Command(@":TRIGger:LEVel " + val.ToDoubleFromEngineerFormat(), false);
                }
                else if ((k = word.IndexOf("TrigSrc:", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(k + 8);
                    this.Command(@":TRIGger:SOURce " + val.ToUpper(), false);
                }
                else if ((k = word.IndexOf("TrigCoup:", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(k + 9);
                    this.Command(@":TRIGger:COUPle " + val.ToUpper(), false);
                }
                else if ((k = word.IndexOf("TrigMode:", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(k + 9);
                    this.Command(@":TRIG:MOD " + val.ToUpper(), false);
                }
                else if ((k = word.IndexOf("Avg", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(0, k);
                    int d = int.Parse(val);
                    if (d <= 1)
                        this.Command(@":ACQuire:MODe SAMPle");
                    else
                    {
                        this.Command(@":ACQuire:MODe AVERage");
                        this.Command(@":ACQuire:AVERage " + d.ToString(), false);
                    }
                }
                else if ((k = word.IndexOf("Smps", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    string val = word.Substring(0, k);
                    double d = val.ToDoubleFromEngineerFormat();
                    int d2 = (int)Math.Round(d);
                    this.Command(@":ACQuire:RECOrdlength " + d.ToString());
                }
            }
        }
        public double Measure(string str)
        {
            //try
            //{
            //    Flush();
            //}
            //catch (Exception ex)
            //{

            //}
            string val;
            switch (str.ToLower())
            {
                case "rect":
                    return EvalRect();
                case "dist":
                    return Distortion();
                case "tfreq":
                    val = Command(@":TRIGger:FREQuency?");
                    break;
                case "mean":
                    val = Command(@":MEASure:MEAN?");
                    break;
                case "cmean":
                    val = Command(@":MEASure:CMEan?");
                    break;
                case "amp":
                    val = Command(@":MEASure:AMPlitude?");
                    break;
                case "rms":
                    val = Command(@":MEASure:RMS?");
                    break;
                case "crms":
                    val = Command(@":MEASure:CRMS?");
                    break;
                case "p2p":
                    val = Command(@":MEASure:PK2Pk?");
                    break;
                case "freq":
                    val = Command(@":MEASure:FREQuency?");
                    break;
                case "period":
                    val = Command(@":MEASure:PERiod?");
                    break;
                case "pwidth":
                    val = Command(@":MEASure:PWIDth?");
                    break;
                case "duty":
                case "pduty":
                    val = Command(@":MEASure:PDUTy?");
                    break;
                case "rovshoot":
                    val = Command(@":MEASure:ROVShoot?");
                    break;
                case "rpreshoot":
                    val = Command(@":MEASure:RPReshoot?");
                    break;
                case "high":
                    val = Command(@":MEASure:HIGH?");
                    break;
                case "low":
                    val = Command(@":MEASure:LOW?");
                    break;
                case "rrdly":
                    val = Command(@":MEASure:FRRDelay?");
                    break;
                case "rfdly":
                    val = Command(@":MEASure:FRFDelay?");
                    break;
                case "frdly":
                    val = Command(@":MEASure:FFRDelay?");
                    break;
                case "ffdly":
                    val = Command(@":MEASure:FFFDelay?");
                    break;
                case "phase":
                    val = Command(@":MEASure:PHAse?");
                    break;
                default: return double.NaN;
            }
            double rtn;
            if(double.TryParse(val, out rtn))
                return rtn;
            else
                return double.NaN;
        }
        private void calcHarmPowers(double[] psd, double fbase, out double pBase, out double pHarm, out double pNoi)
        {
            const double fres = 1.0;
            double pb = 0.0, ph = 0.0, pn = 0.0;
            double frng = fres * 5;
            double f = 0.0;
            for (int i = 0; i < psd.Length; i++, f += fres)
            {
                int h = (int)Math.Round(f / fbase);
                bool isbase = f.InColseRange(fbase - frng, fbase + frng);
                bool isharm = h > 1 && f.InColseRange(fbase * h - frng, fbase * h + frng);
                if (isbase)
                {
                    pb += psd[i] * fres;
                }
                else if (isharm)
                {
                    ph += psd[i] * fres;
                }
                else
                {
                    pn += psd[i] * fres;
                }
            }
            pBase = pb;
            pHarm = ph;
            pNoi = pn;
        }

        private void acqMemAndCalcHarmPowers(out double pBase, out double pHarm, out double pNoi)
        {
            int m = 13;
            int len = (1 << m);
            short[] wave = new short[10000];
            int l = AcquireMemory(wave);
            Debug.Assert(l == 10000);
            double mean = 0;
            for(int i = 0; i < len; i++)
            {
                mean += wave[i];
            }
            mean /= len;
            Complex[] x = new Complex[len];
            for(int i = 0; i < len; i++)
            {
                x[i] = (double)wave[i] - mean;
            }
            FFT fft = new(13, FFT.Windows.Kaiser, 10.0);
            double sr = (double)len;
            double fres = 1.0;
            double[] psd = fft.PowerSpectrumDensity(sr, ref x);
            double p1 = double.MinValue;
            int i1 = 0;
            for (int i = 0; i < psd.Length; i++)
            {
                if (psd[i] > p1)
                {
                    p1 = psd[i];
                    i1 = i;
                }
            }
            double f1 = fres * i1;
            double fpeak;
            if (i1 > 1 && i1 < psd.Length - 1)
            {
                double f0 = f1 - fres;
                double f2 = f1 + fres;
                //p1 *= p1;
                double p0 = psd[i1 - 1];// * psd[i1 - 1];
                double p2 = psd[i1 + 1];// * psd[i1 + 1];
                fpeak = (f0 * p0 + f1 * p1 + f2 * p2) / (p0 + p1 + p2);
            }
            else
            {
                fpeak = f1;
            }
            calcHarmPowers(psd, fpeak, out pBase, out pHarm, out pNoi);
        }
        private double Distortion()
        {
            double pBase, pHarm, pNoi;
            acqMemAndCalcHarmPowers(out pBase, out pHarm, out pNoi);
            return Math.Sqrt(pHarm / pBase);
        }
        private double EvalRect()
        {
            double pBase, pHarm, pNoi;
            acqMemAndCalcHarmPowers(out pBase, out pHarm, out pNoi);
            double harmDist = Math.Sqrt(pHarm / pBase);
            double rTime = MeasureRise();
            double fTime = MeasureFall();
            double period = MeasurePeriod();
            double distErr = Math.Abs(harmDist - 0.483);
            double rfDuty = (rTime + fTime) / period;
            if (distErr < 0.03 && rfDuty < 0.05)
                return 1.0;
            else if (distErr < 0.05 && rfDuty < 0.08)
                return 0.9;
            else if (distErr < 0.08 && rfDuty < 0.10)
                return 0.8;
            else if (distErr < 0.10 && rfDuty < 0.12)
                return 0.7;
            else if (distErr < 0.15 && rfDuty < 0.15)
                return 0.6;
            else if (distErr < 0.2 && rfDuty < 0.2)
                return 0.5;
            else
                return 0.0;
        }
        //public double ApplySettingsAndMeasure(string setStr, string meaStr)
        //{
        //    this.ParseAndSetFromString(setStr);
        //    return this.Measure(meaStr);
        //}
    }
}
