using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace NuedcCompTestAutoScoring
{
    class FFT
    {
        public enum Windows : int
        {
            Rectangular = 0,
            Bartlett = 1,
            Hanning = 2,
            Hamming = 3,
            Kaiser = 4

        };
        private Complex[] w;
        private double[] wind;
        private double windPwr;
        private int len;
        private int m = 0;
        private Windows windType;
        private double beta;
        public int Length
        {
            get
            {
                return this.len;
            }
        }
        public int M
        {
            get
            {
                return this.m;
            }
        }
        public Windows WindowType
        {
            get
            {
                return this.windType;
            }
        }
        public FFT(int m, Windows wind, double beta = 1.0)
        {
            Reset(m, wind, beta);
        }
        public void Reset(int m, Windows windType, double beta = 1.0)
        {
            if (m == this.m && windType == this.windType)
            {
                if (windType == Windows.Kaiser)
                {
                    if (beta == this.beta)
                    {
                        return;
                    }
                }
                else
                    return;
            }
            this.m = m;
            this.len = 1 << m;
            this.windType = windType;
            this.beta = beta;
            this.w = new Complex[1 << (m - 1)];
            this.wind = new double[1 << m];
            calcW(ref w);
            switch (windType)
            {
                case Windows.Rectangular:
                    windPwr = RectangularWindow(ref wind);
                    break;
                case Windows.Bartlett:
                    windPwr = BartlettWindow(ref wind);
                    break;
                case Windows.Hanning:
                    windPwr = HanningWindow(ref wind);
                    break;
                case Windows.Hamming:
                    windPwr = HammingWindow(ref wind);
                    break;
                case Windows.Kaiser:
                    windPwr = KaiserWindow(ref wind, beta);
                    break;
                default:
                    break;
            }
        }
        public Complex[] Transfer(ref Complex[] x, int a = -1,int b= 1)
        {
            Complex[] y = new Complex[this.len];
            Transfer(ref x, 0, ref y, a, b);
            return y;
        }
        public Complex[] Transfer(ref Complex[] x, int xBegin, int a = -1, int b = 1)
        {
            Complex[] y = new Complex[this.len];
            Transfer(ref x, xBegin, ref y, a, b);
            return y;
        }
        public void Transfer(ref Complex[] x, ref Complex[] y, int a = -1, int b = 1)
        {
            Transfer(ref x, 0, ref y, a, b);
        }
        public void Transfer(ref Complex[] x, int xBegin, ref Complex[] y, int a = -1, int b = 1)
        {
            if (x.Length < xBegin + this.len || y.Length < this.len)
                throw new ArgumentOutOfRangeException();
            Complex u, v;
            double gain =
                    a == -1 ? 1.0 / len :
                    a == 0 ? 1.0 / Math.Sqrt(len) : (double)1.0;
            for (int i = 0; i < len; i++)
            {
                y[i] = x[i + xBegin] * gain * wind[i];
            }
            for (int step = 0, gLen = (len >> 1); step < m; step++, gLen >>= 1)
            {
                for (int grp = 0; grp < len; grp += (gLen << 1))
                {
                    for (int i = grp, j = grp + gLen, k = 0;
                        i < grp + gLen;
                        i++, j++, k += (1 << step))
                    {
                        u = y[i] + y[j];
                        if (b < 0)
                            v = (y[i] - y[j]) * Complex.Conjugate(w[k]);
                        else
                            v = (y[i] - y[j]) * w[k];
                        y[i] = u;
                        y[j] = v;
                    }
                }
            }
            for (uint i = 0; i < len; i++)
            {
                uint j = bitRev(i, m);
                if (i < j)
                    swap(ref y[i], ref y[j]);
            }
        }
        public double[] PowerSpectrumDensity(double smpRate, ref Complex[] x)
        {
            double[] psd = new double[this.len];
            PowerSpectrumDensity(smpRate, ref x, 0, ref psd);
            return psd;
        }
        public double[] PowerSpectrumDensity(double smpRate, ref Complex[] x, int xBegin)
        {
            double[] psd = new double[this.len];
            PowerSpectrumDensity(smpRate, ref x, xBegin, ref psd);
            return psd;
        }
        public void PowerSpectrumDensity(double smpRate, ref Complex[] x, ref double[] psd)
        {
            PowerSpectrumDensity(smpRate, ref x, 0, ref psd);
        }
        public void PowerSpectrumDensity(double smpRate, ref Complex[] x, int xBegin, ref double[] psd)
        {
            if (x.Length < xBegin + this.len || psd.Length < this.len / 2)
                throw new ArgumentOutOfRangeException();
            double fres = smpRate / this.len;
            Complex[] y = Transfer(ref x);
            psd[0] = y[0].Magnitude * y[0].Magnitude / windPwr;
            for(int i = 1; i < this.len / 2; i++)
            {
                psd[i] = y[i].Magnitude * y[i].Magnitude * 2.0 / windPwr / fres;
            }
        }
        private void calcW(ref Complex[] w)
        {
            int len = w.Length * 2;
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = Complex.Exp(Complex.ImaginaryOne * 
                    (2.0 * Math.PI * (double)i / (double)len));
            }
        }
        private readonly uint[] lmask = {
                0x55555555, 0x33333333, 0x0f0f0f0f, 0x00ff00ff, 0x0000ffff};
        private readonly uint[] umask = {
                0xaaaaaaaa, 0xcccccccc, 0xf0f0f0f0, 0xff00ff00, 0xffff0000};
        private uint bitRev(uint data, int n)
        {
            int g, gi;
            for (g = 1, gi = 0; g < n; g <<= 1, gi++)
            {
                data = ((data & umask[gi]) >> g) | ((data & lmask[gi]) << g);
            }
            return data >> (g - n);
        }
        private void swap(ref Complex a, ref Complex b)
        {
            Complex t;
            t = a;
            a = b;
            b = t;
        }
        static private double besseli0(double x)
        {
            double e, z = 0, de, sde;
            int i;
            x /= 2.0;
            e = de = 1.0;
            for (i = 1; i <= 48; i++)
            {
                de *= (x / i);
                sde = de * de;
                e += sde;
                if (e * 1.0e-24 > sde)
                    z = e;
            }
            return z;
        }
        static public double RectangularWindow(ref double[] w)
        {
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = 1.0;
            }
            return 1.0;
        }
        static public double BartlettWindow(ref double[] w)
        {
            double k = 2.0 / ((double)w.Length + 1);
            int i;
            for (i = 0; i < w.Length / 2; i++)
            {
                w[i] = (double)(i + 1) * k;
            }
            for (; i < w.Length; i++)
            {
                w[i] = 2.0 - (double)(i + 1) * k;
            }
            double pwr = 0.0;
            foreach (double d in w)
            {
                pwr += d * d;
            }
            return pwr / (double)w.Length;
        }
        static public double HanningWindow(ref double[] w)
        {
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = 0.5 - 0.5 * Math.Cos(2.0 * Math.PI * (i + 1) / (w.Length + 1));
            }
            double pwr = 0.0;
            foreach (double d in w)
            {
                pwr += d * d;
            }
            return pwr / (double)w.Length;
        }
        static public double HammingWindow(ref double[] w)
        {
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = 0.54 - 0.46 * Math.Cos(2.0 * Math.PI * i / (w.Length - 1));
            }
            double pwr = 0.0;
            foreach (double d in w)
            {
                pwr += d * d;
            }
            return pwr / (double)w.Length;
        }
        static public double BlackmanWindow(ref double[] w)
        {
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = 0.42 - 0.5 * Math.Cos(2.0 * Math.PI * i / (w.Length - 1))
                           + 0.08 * Math.Cos(4.0 * Math.PI * i / (w.Length - 1));
            }
            double pwr = 0.0;
            foreach (double d in w)
            {
                pwr += d * d;
            }
            return pwr / (double)w.Length;
        }
        static public double KaiserWindow(ref double[] w, double beta)
        {
            double b = besseli0(beta);
            for (int i = 0; i < w.Length; i++)
            {
                double a = beta * Math.Sqrt(1.0 - Math.Pow(1.0 - 2.0 * (i) / (w.Length - 1), 2));
                w[i] = besseli0(a) / b;
            }
            double pwr = 0.0;
            foreach (double d in w)
            {
                pwr += d * d;
            }
            return pwr / (double)w.Length;
        }
    }
}
