using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuedcCompTestAutoScoring
{
    public static class EngineerFormatExt
    {
        public static bool InColseRange(this double x, double l, double h)
        {
            return l <= x && x <= h;
        }
        public static float Saturate(this float x, float l, float h)
        {
            return x < l ? l : x > h ? h : x;
        }
        public static double Saturate(this double x, double l, double h)
        {
            return x < l ? l : x > h ? h : x;
        }
        public static uint Saturate(this uint x, uint l, uint h)
        {
            return x < l ? l : x > h ? h : x;
        }
        public static string ToEngineerFormatString(this double v, int effNum = 3, bool posSign = false)
        {
            char[] engSuffix = new char[] { 'y', 'z', 'a', 'f', 'p', 'n', 'μ', 'm', ' ', 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
            if (effNum < 3) effNum = 3;
            int s = Math.Sign(v);
            v = Math.Abs(v);
            string vestr = v.ToString(string.Format("e{0}", effNum - 1));
            double val = double.Parse(vestr);
            if (val >= Math.Pow(10.0, 27.0))
                return (s == -1 ? "-" : posSign ? "+" : " ") + vestr;
            for (int e = 24; e >= -24; e -= 3)
            {
                for (int d = 2; d >= 0; d--)
                {
                    if (val >= Math.Pow(10.0, (double)(e + d)))
                        return (s == -1 ? "-" : posSign ? "+" : " ") + 
                            (val / Math.Pow(10.0, (double)e)).ToString(String.Format("N{0}", effNum - 1 - d))
                            + (effNum - 1 - d == 0 ? "." : "")
                            + engSuffix[e / 3 + 8];
                }
            }
            if (val == 0.0)
                return "0";
            else
                return (s == 0 ? " " : s == -1 ? "-" : posSign ? "+" : " ") + val.ToString(String.Format("e{0}", effNum - 1)) + " ";
        }

        public static string ToEngineerFormatString(this float v, int effNum = 3, bool posSign = false)
        {
            char[] engSuffix = new char[] { 'y', 'z', 'a', 'f', 'p', 'n', 'μ', 'm', ' ', 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
            if (effNum < 3) effNum = 3;
            int s = Math.Sign(v);
            v = Math.Abs(v);
            string vestr = v.ToString(string.Format("e{0}", effNum - 1));
            float val = float.Parse(vestr);
            if (val >= (float)Math.Pow(10.0, 27.0))
                return (s == -1 ? "-" : posSign ? "+" : " ") + vestr;
            for (int e = 24; e >= -24; e -= 3)
            {
                for (int d = 2; d >= 0; d--)
                {
                    if (val >= (float)Math.Pow(10.0, (double)(e + d)))
                        return (s == -1 ? "-" : posSign ? "+" : " ") +
                            (val / (float)Math.Pow(10.0, (double)e)).ToString(String.Format("N{0}", effNum - 1 - d))
                            + (effNum - 1 - d == 0 ? "." : "")
                            + engSuffix[e / 3 + 8];
                }
            }
            if (val == 0.0)
                return "0";
            else
                return (s == 0 ? " " : s == -1 ? "-" : posSign ? "+" : " ") + val.ToString(String.Format("e{0}", effNum - 1)) + " ";
        }
        public static double ToDoubleFromEngineerFormat(this string s)
        {
            s = s.Trim();
            if (s.Length == 0)
                return 0.0;
            else if (s == "-")
                return 0.0;
            char c = s[s.Length - 1];
            double ratio;
            bool noSufix = false;
            string num;
            double rtn;
            switch (c)
            {
                case 'y': ratio = 1.0e-24; break;
                case 'z': ratio = 1.0e-21; break;
                case 'a': ratio = 1.0e-18; break;
                case 'f': ratio = 1.0e-15; break;
                case 'p': ratio = 1.0e-12; break;
                case 'n': ratio = 1.0e-9; break;
                case 'u': ratio = 1.0e-6; break;
                case 'μ': ratio = 1.0e-6; break;
                case 'm': ratio = 1.0e-3; break;
                case 'k': ratio = 1.0e3; break;
                case 'M': ratio = 1.0e6; break;
                case 'G': ratio = 1.0e9; break;
                case 'T': ratio = 1.0e12; break;
                case 'P': ratio = 1.0e15; break;
                case 'E': ratio = 1.0e18; break;
                case 'Z': ratio = 1.0e21; break;
                case 'Y': ratio = 1.0e24; break;
                default:
                    ratio = 1.0;
                    noSufix = true;
                    break;
            }
            if (noSufix)
                num = s;
            else
                num = s.Substring(0, s.Length - 1);

            try
            {
                rtn = double.Parse(num);
            }
            catch (Exception e)
            {
                rtn = double.NaN;
                throw new ArgumentException("Eng-Num format error!", e);
            }

            return rtn * ratio;
        }

        public static float ToFloatFromEngineerFormat(this string s)
        {
            s = s.Trim();
            if (s.Length == 0)
                return 0.0f;
            else if (s == "-")
                return 0.0f;
            char c = s[s.Length - 1];
            float ratio;
            bool noSufix = false;
            string num;
            float rtn;
            switch (c)
            {
                case 'y': ratio = 1.0e-24f; break;
                case 'z': ratio = 1.0e-21f; break;
                case 'a': ratio = 1.0e-18f; break;
                case 'f': ratio = 1.0e-15f; break;
                case 'p': ratio = 1.0e-12f; break;
                case 'n': ratio = 1.0e-9f; break;
                case 'u': ratio = 1.0e-6f; break;
                case 'μ': ratio = 1.0e-6f; break;
                case 'm': ratio = 1.0e-3f; break;
                case 'k': ratio = 1.0e3f; break;
                case 'M': ratio = 1.0e6f; break;
                case 'G': ratio = 1.0e9f; break;
                case 'T': ratio = 1.0e12f; break;
                case 'P': ratio = 1.0e15f; break;
                case 'E': ratio = 1.0e18f; break;
                case 'Z': ratio = 1.0e21f; break;
                case 'Y': ratio = 1.0e24f; break;
                default:
                    ratio = 1.0f;
                    noSufix = true;
                    break;
            }
            if (noSufix)
                num = s;
            else
                num = s.Substring(0, s.Length - 1);

            try
            {
                rtn = float.Parse(num);
            }
            catch (Exception e)
            {
                rtn = float.NaN;
                throw new ArgumentException("Eng-Num format error!", e);
            }

            return rtn * ratio;
        }
    }
}
