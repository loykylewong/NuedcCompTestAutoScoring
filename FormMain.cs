using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using ExpressionAnalyzer;

namespace NuedcCompTestAutoScoring
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private Socket? soc = null;

        private void init_DgvScoreDetail()
        {
            this.dgvScoreDetail.RowCount = (int)this.numScoreItemQuantity.Value;
            this.dgvScoreDetail.ColumnCount = 9;
            foreach (DataGridViewColumn col in this.dgvScoreDetail.Columns)
            {
                col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            }
            this.dgvScoreDetail.ColumnHeadersVisible = true;
            {
                this.dgvScoreDetail.Columns[0].HeaderText = "序号";
                this.dgvScoreDetail.Columns[1].HeaderText = "测量项目描述";
                this.dgvScoreDetail.Columns[2].HeaderText = "提示信息";
                this.dgvScoreDetail.Columns[3].HeaderText = "测量通道";
                this.dgvScoreDetail.Columns[4].HeaderText = "仪器设定";
                this.dgvScoreDetail.Columns[5].HeaderText = "测量量";
                this.dgvScoreDetail.Columns[6].HeaderText = "分数算式";
                this.dgvScoreDetail.Columns[7].HeaderText = "测量值";
                this.dgvScoreDetail.Columns[8].HeaderText = "分数";
                this.dgvScoreDetail.Columns[8].ReadOnly = true;
            }
            int i = 1;
            foreach(DataGridViewRow row in this.dgvScoreDetail.Rows)
            {
                row.Cells[0].Value = i++;
            }
            {
                dgvScoreDetail.Rows[0].Cells[1].Value = "方波信号的品质";
                dgvScoreDetail.Rows[0].Cells[2].Value = "";
                dgvScoreDetail.Rows[0].Cells[3].Value = "1,1";
                dgvScoreDetail.Rows[0].Cells[4].Value = @"DC, 1V/div, -1Vpos, 100us/div";
                dgvScoreDetail.Rows[0].Cells[5].Value = "Rect";
                dgvScoreDetail.Rows[0].Cells[6].Value = "x";
                dgvScoreDetail.Rows[0].Cells[7].Value = "";
            }
            {
                dgvScoreDetail.Rows[1].Cells[1].Value = "方波信号的幅值";
                dgvScoreDetail.Rows[1].Cells[2].Value = "";
                dgvScoreDetail.Rows[1].Cells[3].Value = "1,1";
                dgvScoreDetail.Rows[1].Cells[4].Value = @"";
                dgvScoreDetail.Rows[1].Cells[5].Value = "P2P";
                dgvScoreDetail.Rows[1].Cells[6].Value = "sat((x-2.2)*2, 0, 2)";
                dgvScoreDetail.Rows[1].Cells[7].Value = "";
            }
            {
                dgvScoreDetail.Rows[2].Cells[1].Value = "方波信号的最小频率";
                dgvScoreDetail.Rows[2].Cells[2].Value = "调整信号频率到19kHz或更小。";
                dgvScoreDetail.Rows[2].Cells[3].Value = "1,1";
                dgvScoreDetail.Rows[2].Cells[4].Value = @"1.6Vtrigr";
                dgvScoreDetail.Rows[2].Cells[5].Value = "FREQ";
                dgvScoreDetail.Rows[2].Cells[6].Value = "sat((19.5e3-x)*2/500, 0, 2)";
                dgvScoreDetail.Rows[2].Cells[7].Value = "";
            }
            {
                dgvScoreDetail.Rows[3].Cells[1].Value = "方波信号的最大频率";
                dgvScoreDetail.Rows[3].Cells[2].Value = "调整信号频率到21kHz或更大。";
                dgvScoreDetail.Rows[3].Cells[3].Value = "1,1";
                dgvScoreDetail.Rows[3].Cells[4].Value = @"";
                dgvScoreDetail.Rows[3].Cells[5].Value = "FREQ";
                dgvScoreDetail.Rows[3].Cells[6].Value = "sat((x-20.5e3)*2/500, 0, 2)";
                dgvScoreDetail.Rows[3].Cells[7].Value = "";
            }
            //{
            //    dgvScoreDetail.Rows[4].Cells[1].Value = "正弦信号的峰峰值";
            //    dgvScoreDetail.Rows[4].Cells[2].Value = "";
            //    dgvScoreDetail.Rows[4].Cells[3].Value = "2,1";
            //    dgvScoreDetail.Rows[4].Cells[4].Value = @"0Vpos, 0.5V/div, 50us/div";
            //    dgvScoreDetail.Rows[4].Cells[5].Value = "P2P";
            //    dgvScoreDetail.Rows[4].Cells[6].Value = "min(2, (x-1)*2/0.5+2)";
            //    dgvScoreDetail.Rows[4].Cells[7].Value = "";
            //}
            //{
            //    dgvScoreDetail.Rows[5].Cells[1].Value = "正弦信号的失真度";
            //    dgvScoreDetail.Rows[5].Cells[2].Value = "";
            //    dgvScoreDetail.Rows[5].Cells[3].Value = "2,1";
            //    dgvScoreDetail.Rows[5].Cells[4].Value = @"0.5V/div, 100us/div";
            //    dgvScoreDetail.Rows[5].Cells[5].Value = "Dist";
            //    dgvScoreDetail.Rows[5].Cells[6].Value = "min(2, (0.02-x)*2/0.1+2)";
            //    dgvScoreDetail.Rows[5].Cells[7].Value = "";
            //}
        }
        private void init_GdvEntries()
        {
            this.dgvEntries.RowCount = (int)this.numEntriesQuantity.Value;
            this.dgvEntries.ColumnCount = 7;
            this.dgvEntries.ColumnHeadersVisible = true;
            {
                this.dgvEntries.Columns[0].HeaderText = "序号";
                this.dgvEntries.Columns[1].HeaderText = "作品编号";
                this.dgvEntries.Columns[2].HeaderText = "仪器IP";
                this.dgvEntries.Columns[3].HeaderText = "仪器端口";
                this.dgvEntries.Columns[4].HeaderText = "仪器ID";
                this.dgvEntries.Columns[5].HeaderText = "总分算式";
                this.dgvEntries.Columns[6].HeaderText = "分数";
                this.dgvEntries.Columns[6].ReadOnly = true;
            }
            int i = 1;
            foreach (DataGridViewRow row in this.dgvEntries.Rows)
            {
                row.Cells[0].Value = i;
                row.Cells[1].Value = String.Format("U{0,8:00000000}", i);
                row.Cells[2].Value = String.Format("192.168.2.{0}", i + 1);
                row.Cells[3].Value = "3000".ToString();
                i++;
            }
        }
        private void gwScpi_Test()
        {
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //soc.Bind(new IPEndPoint(IPAddress.Parse("192.168.2.10"), 0));
            soc.ReceiveTimeout = 2000;
            soc.SendTimeout = 2000;
            byte[] rxbuf = new byte[soc.ReceiveBufferSize];
            short[] data = new short[soc.ReceiveBufferSize / 2];
            soc.Connect(new IPEndPoint(IPAddress.Parse("192.168.2.2"), 3000));
            GwScpi gwScpi = new(
                (byte[] tx, int o, int l) => soc.Send(tx, o, l, SocketFlags.None),
                (byte[] rx, int o, int l) => soc.Receive(rx, o, l, SocketFlags.None)
                );
            //soc.Send(Encoding.ASCII.GetBytes(@"*idn?\n"));
            //int len = soc.Receive(rxbuf);
            //string rtn = Encoding.ASCII.GetString(rxbuf);
            string rtn = gwScpi.Command(@"*idn?");
            rtn = gwScpi.Command(@":MEASure:SOURce1 CH1", false);
            rtn = gwScpi.Command(@":MEASure:PK2Pk?");
            rtn = gwScpi.Command(@":MEASure:PK2Pk?");
            gwScpi.AcquireMemory(data);
            rtn = gwScpi.Command(@":MEASure:PK2Pk?");
            rtn = gwScpi.Command(@":MEASure:PK2Pk?");
            rtn = gwScpi.Command(@":MEASure:PK2Pk?");
            Console.WriteLine(rtn);

        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            init_DgvScoreDetail();
            init_GdvEntries();
        }

        private void numScoreItemQuantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown me = (NumericUpDown)sender;
            int rcnt = this.dgvScoreDetail.Rows.Count;
            int add = (int)me.Value - rcnt;
            if (add > 0)
            {
                this.dgvScoreDetail.Rows.Add(add);
                int i = 1;
                foreach (DataGridViewRow row in this.dgvScoreDetail.Rows)
                {
                    row.Cells[0].Value = i++;
                }
            }
            for (int i = rcnt - 1; i >= rcnt + add; i--)
            {
                this.dgvScoreDetail.Rows.RemoveAt(i);
            }
        }

        private void numEntriesQuantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown me = (NumericUpDown)sender;
            int rcnt = this.dgvEntries.Rows.Count;
            int add = (int)me.Value - rcnt;
            if (add > 0)
            {
                this.dgvEntries.Rows.Add(add);
                int i = 1;
                foreach (DataGridViewRow row in this.dgvEntries.Rows)
                {
                    row.Cells[0].Value = i++;
                }
            }
            for (int i = rcnt - 1; i >= rcnt + add; i--)
            {
                this.dgvEntries.Rows.RemoveAt(i);
            }
        }

        //private Dictionary<string, string> ParseSettingString(string str)
        //{
        //    Dictionary<string, string> result = new Dictionary<string, string>();
        //    int len = str.Length;
        //    for(int i = 0, j = 0; i < len; i = j + 1)
        //    {
        //        j = str.IndexOf(",", i);
        //        string word = str.Substring(i, j - i);
        //        if (word.Contains("DC", StringComparison.OrdinalIgnoreCase))
        //        {
        //            result.Add("DC", "");
        //        }
        //        else if (word.Contains("AC", StringComparison.OrdinalIgnoreCase))
        //        {
        //            result.Add("AC", "");
        //        }
        //        int k;
        //        if((k = word.IndexOf("V/div", StringComparison.OrdinalIgnoreCase)) > 0)
        //        {
        //            string val = word.Substring(0, k);
        //            result.Add("VScale", val);
        //        }
        //        else if((k = word.IndexOf("s/div", StringComparison.OrdinalIgnoreCase)) > 0)
        //        {
        //            string val = word.Substring(0, k);
        //            result.Add("HScale", val);
        //        }
        //    }
        //    return result;
        //}

        private GwScpi? GetGwScpiFromIpAndEp(string ip, string port)
        {
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soc.ReceiveTimeout = 1000;
            soc.SendTimeout = 1000;

            IAsyncResult result = soc.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), int.Parse(port)), null, null);

            bool success = result.AsyncWaitHandle.WaitOne(1000, true);

            if (soc.Connected)
            {
                GwScpi gwScpi = new(
                    (byte[] tx, int o, int l) => soc.Send(tx, o, l, SocketFlags.None),
                    (byte[] rx, int o, int l) => soc.Receive(rx, o, l, SocketFlags.None)
                    );
                return gwScpi;
            }
            else
            {
                soc.Close();
                return null;
            }
        }

        private void btnTestIns_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow er in dgvEntries.Rows)
            {
                er.Cells[4].Value = string.Empty;
            }
            bool hasSel = false;
            foreach(DataGridViewRow row in this.dgvEntries.Rows)
            {
                if(row.Selected)
                {
                    hasSel = true;
                    try
                    {
                        GwScpiEth gw = new((string)row.Cells[2].Value, (string)row.Cells[3].Value);
                        row.Cells[4].Value = gw.Scpi.Command(@"*idn?");
                        gw.Close();
                    }
                    catch(Exception)
                    {
                        row.Cells[4].Value = "连接失败";
                    }
                }
            }
            if(!hasSel)
            {
                MessageBox.Show("请在作品列表中至少选择一项。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private GwScpiEth? TryOpenInsFromEntryRow(DataGridViewRow row)
        {
            GwScpiEth? gw = null;
            try
            {
                gw = new((string)row.Cells[2].Value, (string)row.Cells[3].Value);
                row.Cells[4].Value = gw.Scpi.Command(@"*idn?");
                return gw;
            }
            catch (Exception)
            {
                row.Cells[4].Value = "连接失败";
                return gw;
            }
        }

        private void getIchAndEch(string str, out int ich, out int ech)
        {
            int comma = str.IndexOf(',');
            if(comma > 0)
            {
                ich = int.Parse(str.Substring(0, comma));
                ech = int.Parse(str.Substring(1 + comma));
            }
            else
            {
                if(str.Length == 0)
                    ich = 0;
                else
                    ich = int.Parse(str);
                ech = 0;
            }
        }
        private void DoMeasureRow(GwScpiEth gw, DataGridViewRow row)
        {
            string? promt = (string)row.Cells[2].Value;
            if (promt != null && promt.Length > 0)
            {
                MessageBox.Show((string)promt, "请按提示操作，完成后按“OK”", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string ch = (string)row.Cells[3].Value;
            if (ch == null)
            {
                MessageBox.Show("测量通道填写不正确。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells[8].Value = string.Empty;
                return;
            }   
            int colon = ch.IndexOf(':');
            string? chstr, rchstr;
            if (colon > 0)
            { 
                chstr = ch.Substring(0, colon);
                rchstr = ch.Substring(colon + 1);
            }
            else
            {
                chstr = ch;
                rchstr = String.Empty;
            }
            int ich, ech, rich, rech;
            try
            {
                getIchAndEch(chstr, out ich, out ech);
                getIchAndEch(rchstr, out rich, out rech);
            }
            catch
            {
                MessageBox.Show("测量通道填写不正确。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells[8].Value = string.Empty; 
                return;
            }
            gw.Scpi.ParseAndSetFromString(ich, (string)row.Cells[4].Value);
            if (rich > 0)
                gw.Scpi.MeasureSource(ich, rich);
            else
                gw.Scpi.MeasureSource(ich);
            gw.Scpi.AcqMemCh = ich;
            Thread.Sleep(250);
            if (row.Cells[5].Value != null)
            {
                double val = gw.Scpi.Measure((string)row.Cells[5].Value);
                if (!double.IsNaN(val))
                {
                    row.Cells[7].Value = val.ToEngineerFormatString(6);
                    try
                    {
                        //======== old ExprAnalyzer >>>>>>>>
                        //ExprAnalyzer.Variable vars = new("x", val);
                        //ExprAnalyzer ea = new ExprAnalyzer((string)row.Cells[6].Value, new ExprAnalyzer.Variable[1] { vars });
                        //==================================
                        ExprAnalyzer ea = new ExprAnalyzer((string)row.Cells[6].Value);
                        ea.Variables.Add("x", val);
                        //<<<<<<<< new ExprAnalyzer ========
                        row.Cells[8].Value = ea.Value.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("得分表达式填写不正确。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells[8].Value = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("测量量填写不正确，或没有测到有效的值。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells[8].Value = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("测量量填写不正确。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells[8].Value = string.Empty;
            }
        }

        private void btnTestMeasure_Click(object sender, EventArgs e)
        {
            GwScpiEth? gw = null;
            bool hasSel = false;
            foreach (DataGridViewRow row in this.dgvEntries.Rows)
            {
                if (row.Selected)
                {
                    hasSel = true;
                    //try
                    //{
                    //    gw = new((string)row.Cells[2].Value, (string)row.Cells[3].Value);
                    //    row.Cells[4].Value = gw.Scpi.Command(@"*idn?");
                    //    break;
                    //}
                    //catch (Exception ex)
                    //{
                    //    row.Cells[4].Value = "连接失败";
                    //    MessageBox.Show("所选仪器连接失败，请选择其它仪器再试。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    gw = this.TryOpenInsFromEntryRow(row);
                }
            }
            if(!hasSel)
            {
                MessageBox.Show("请在作品列表中选择一项再试。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gw == null)
            {
                MessageBox.Show("连接失败，请检查以太网连接、IP和端口设置。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //this.dgvScoreDetail.Sort
            hasSel = false;
            foreach(DataGridViewRow row in this.dgvScoreDetail.Rows)
            {
                if(row.Selected)
                {
                    hasSel = true;
                    //string? promt = (string)row.Cells[2].Value;
                    //if(promt != null && promt.Length > 0)
                    //{
                    //    MessageBox.Show((string)promt, "请按提示操作，完成后按“OK”", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //string ch = (string)row.Cells[3].Value;
                    //int comma = ch.IndexOf(',');
                    //int ich = 0, ech = 0;
                    //if (comma > 0)
                    //{
                    //    ich = int.Parse(ch.Substring(0, comma));
                    //    ech = int.Parse(ch.Substring(comma + 1, ch.Length - comma - 1));
                    //}
                    //gw.Scpi.ParseAndSetFromString(ich, (string)row.Cells[4].Value);
                    //gw.Scpi.MeasureSource(ich);
                    ////Thread.Sleep(100);
                    //double val = gw.Scpi.Measure((string)row.Cells[5].Value);
                    //row.Cells[7].Value = val.ToEngineerFormatString(7);
                    //ExprAnalyse.Variable vars = new("x", val);
                    //ExprAnalyse ea = new ExprAnalyse((string)row.Cells[6].Value, new ExprAnalyse.Variable[1] { vars });
                    //row.Cells[8].Value = ea.Value;
                    DoMeasureRow(gw, row);
                }
            }
            if(!hasSel)
            {
                MessageBox.Show("请在评分项中选择一项再试。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            gw.Close();
        }

        private void btnEvalSelected_Click(object sender, EventArgs e)
        {
            this.dgvEntries.Enabled = false;
            this.dgvScoreDetail.Enabled = false;
            foreach (DataGridViewRow er in dgvEntries.Rows)
            {
                er.Cells[4].Value = string.Empty;
                er.Cells[6].Value = string.Empty;
            }
            bool hasSel = false;
            foreach (DataGridViewRow er in dgvEntries.Rows)
            {
                if (er.Selected)
                {
                    hasSel = true;
                    GwScpiEth? gw = TryOpenInsFromEntryRow(er);
                    if(gw != null)
                    {
                        foreach(DataGridViewRow sr in dgvScoreDetail.Rows)
                        {
                            DoMeasureRow(gw, sr);
                        }
                        //======== use old ExprAnalyzer >>>>>>>>
                        //ExprAnalyzer.Variable[] vars = new ExprAnalyzer.Variable[dgvScoreDetail.Rows.Count * 2];
                        //for (int i = 0; i < dgvScoreDetail.Rows.Count; i++)
                        //{
                        //    vars[2 * i].Name = "m" + (1 + i).ToString();
                        //    string valstr = (string)(dgvScoreDetail.Rows[i].Cells[7].Value);
                        //    if(valstr != null)
                        //        vars[2 * i].Value = valstr.ToDoubleFromEngineerFormat();
                        //    else
                        //        vars[2 * i].Value = double.NaN;

                        //    vars[2 * i + 1].Name = "s" + (1 + i).ToString();
                        //    valstr = (string)(dgvScoreDetail.Rows[i].Cells[8].Value);
                        //    if (valstr != null)
                        //        vars[2 * i + 1].Value = valstr.ToDoubleFromEngineerFormat();
                        //    else
                        //        vars[2 * i + 1].Value = 0;
                        //}
                        //string str = (string)(er.Cells[5].Value);
                        //if(str == null)
                        //    str = "0";
                        //ExprAnalyzer ea = new ExprAnalyzer(str, vars);
                        //===================================
                        ExprAnalyzer ea = new ExprAnalyzer((string)er.Cells[5].Value ?? "");
                        for (int i = 0; i < dgvScoreDetail.Rows.Count; i++)
                        {
                            string name = "m" + (1 + i).ToString();
                            string valstr = (string)(dgvScoreDetail.Rows[i].Cells[7].Value);
                            if (valstr != null)
                                ea.Variables.Add(name, valstr.ToDoubleFromEngineerFormat());
                            else
                                ea.Variables.Add(name, double.NaN);

                            name = "s" + (1 + i).ToString();
                            valstr = (string)(dgvScoreDetail.Rows[i].Cells[8].Value);
                            if (valstr != null)
                                ea.Variables.Add(name, valstr.ToDoubleFromEngineerFormat());
                            else
                                ea.Variables.Add(name, 0);
                        }
                        //<<<<<<<< use new ExprAnalyzer ========
                        er.Cells[6].Value = ea.Value.ToString();
                        gw.Close();
                    }
                }
            }
            if(!hasSel)
            {
                MessageBox.Show("请在作品列表中至少选择一项。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.dgvEntries.Enabled = true;
            this.dgvScoreDetail.Enabled = true;
        }

        private void btnExportScoreDetail_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "逗号分隔的表格(*.csv)|*.csv";
            sfd.Title = "将评分项列表导出到...";
            //sfd.CheckFileExists = true;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(sfd.FileName, FileMode.Create);
                }
                catch(Exception)
                {
                    MessageBox.Show("无法创建文件，如果将被覆盖的文件已被其它应用打开，关闭后重试。", "无法创建文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write("测量项目描述,");
                sw.Write("提示信息,");
                sw.Write("测量通道,");
                sw.Write("仪器设定,");
                sw.Write("测量量,");
                sw.Write("分数算式");
                sw.WriteLine();
                foreach(DataGridViewRow row in this.dgvScoreDetail.Rows)
                {
                    for(int i = 1; i <= 6; i++)
                    {
                        string? str = (string)row.Cells[i].Value;
                        if (str == null)
                        {
                            str = "";
                        }
                        if (str.Contains(','))
                        {
                            str = "\"" + (string)row.Cells[i].Value + "\"";
                        }
                        sw.Write(str);
                        if(i < 6)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
                sw.Close();
                fs.Close();
                MessageBox.Show("文件已保存到" + sfd.FileName, "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImportScoreDetail_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "逗号分隔的表格(*.csv)|*.csv";
            ofd.Title = "选择一个文件打开...";
            ofd.CheckFileExists = true;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                }
                catch
                {
                    MessageBox.Show("文件正被外部应用打开，请关闭后重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StreamReader sw = new StreamReader(fs, Encoding.UTF8);
                int r = 0;
                string? line = sw.ReadLine();   // head line
                if(line == null)
                {
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("文件内容有误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                for(line = sw.ReadLine(); line != null; line = sw.ReadLine(), r++)
                {
                    if (this.dgvScoreDetail.Rows.Count <= r)
                        this.dgvScoreDetail.Rows.Add();
                    int c0 = -1, c1, q1;
                    for(int i = 1; i <= 6; i++)
                    {
                        c1 = line.IndexOf(",", c0 + 1);
                        if (c1 == -1)
                            c1 = line.Length;
                        q1 = line.IndexOf('\"', c0 + 1);
                        if (q1 == -1)
                            q1 = line.Length;
                        string word;
                        if (q1 >= c1)
                        {
                            word = line.Substring(c0 + 1, c1 - c0 - 1);
                        }
                        else
                        {
                            while (q1 < c1)
                            {
                                q1 = line.IndexOf('\"', q1 + 1);
                                if (q1 == -1)
                                    q1 = line.Length;
                            }
                            if (q1 >= line.Length - 1)
                                c1 = line.Length;
                            else
                                c1 = line.IndexOf(",", q1 + 1);
                            word = line.Substring(c0 + 2, c1 - c0 - 3);
                        }
                        this.dgvScoreDetail.Rows[r].Cells[i].Value = word;
                        c0 = c1;
                        if (c0 >= line.Length - 1)
                            break;
                    }
                }
                sw.Close();
                fs.Close();
                this.numScoreItemQuantity.Value = this.dgvScoreDetail.Rows.Count ;
                for (int i = 0; i < this.dgvScoreDetail.Rows.Count; i++)
                {
                    this.dgvScoreDetail.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
        }

        private void btnExportEntries_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "逗号分隔的表格(*.csv)|*.csv";
            sfd.Title = "将评分项列表导出到...";
            //sfd.CheckFileExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(sfd.FileName, FileMode.Create);
                }
                catch (Exception)
                {
                    MessageBox.Show("无法创建文件，如果将被覆盖的文件已被其它应用打开，关闭后重试。", "无法创建文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write("作品编号,");
                sw.Write("仪器IP地址,");
                sw.Write("仪器端口,");
                sw.Write("仪器ID,");
                sw.Write("分数算式,");
                sw.Write("得分");
                sw.WriteLine();
                foreach (DataGridViewRow row in this.dgvEntries.Rows)
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        string? str = (string)row.Cells[i].Value;
                        if (str == null)
                        {
                            str = "";
                        }
                        if (str.Contains(','))
                        {
                            str = "\"" + (string)row.Cells[i].Value + "\"";
                        }
                        sw.Write(str);
                        if (i < 6)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
                sw.Close();
                fs.Close();
                MessageBox.Show("文件已保存到" + sfd.FileName, "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImportEntries_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "逗号分隔的表格(*.csv)|*.csv";
            ofd.Title = "选择一个文件打开...";
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs, Encoding.UTF8);
                int r = 0;
                string? line = sw.ReadLine();   // head line
                if (line == null)
                {
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("文件内容有误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                for (line = sw.ReadLine(); line != null; line = sw.ReadLine(), r++)
                {
                    if (this.dgvEntries.Rows.Count <= r)
                        this.dgvEntries.Rows.Add();
                    int c0 = -1, c1, q1;
                    for (int i = 1; i <= 6; i++)
                    {
                        c1 = line.IndexOf(",", c0 + 1);
                        if (c1 == -1)
                            c1 = line.Length;
                        q1 = line.IndexOf('\"', c0 + 1);
                        if (q1 == -1)
                            q1 = line.Length;
                        string word;
                        if (q1 >= c1)
                        {
                            word = line.Substring(c0 + 1, c1 - c0 - 1);
                        }
                        else
                        {
                            while (q1 < c1)
                            {
                                q1 = line.IndexOf('\"', q1 + 1);
                                if (q1 == -1)
                                    q1 = line.Length;
                            }
                            if (q1 >= line.Length - 1)
                                c1 = line.Length;
                            else
                                c1 = line.IndexOf(",", q1 + 1);
                            word = line.Substring(c0 + 2, c1 - c0 - 3);
                        }
                        this.dgvEntries.Rows[r].Cells[i].Value = word;
                        c0 = c1;
                        if (c0 >= line.Length - 1)
                            break;
                    }
                }
                sw.Close();
                fs.Close();
                this.numEntriesQuantity.Value = this.dgvEntries.Rows.Count;
                for (int i = 0; i < this.dgvEntries.Rows.Count; i++)
                {
                    this.dgvEntries.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
        }

        private void btnCopyExpr_Click(object sender, EventArgs e)
        {
            //DataGridViewSelectedCellCollection scc = this.dgvEntries.SelectedCells;
            bool hasSel = false;
            string? expr = null;
            foreach (DataGridViewRow row in dgvEntries.Rows)
            {
                if (row.Cells[5].Selected)
                {
                    if (hasSel)
                    {
                        MessageBox.Show("请仅选择一个包含公式的单元格。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        hasSel = true;
                    }
                    expr = (string)row.Cells[5].Value;
                }
            }
            if (!hasSel)
            {
                MessageBox.Show("请选择一个包含公式的单元格。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (expr != null)
            {
                foreach (DataGridViewRow row in dgvEntries.Rows)
                {
                    row.Cells[5].Value = expr;
                }
            }
        }
    }
}