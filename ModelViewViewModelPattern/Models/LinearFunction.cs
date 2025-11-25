using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using WpfMath;

namespace ModelViewViewModelPattern.Models
{
    public class LinearFunction
    {
        private double x1 { get; set; }
        private double y1 { get; set; }
        private double x2 { get; set; }
        private double y2 { get; set; }
        private double k_cof { get; set; }
        private double b_cof { get; set; }
        public string FormualText => GetFormulaText();

        public LinearFunction() { }
        public LinearFunction(double _x1, double _y1, double _x2, double _y2)
        {
            x1 = _x1;
            y1 = _y1;
            x2 = _x2;
            y2 = _y2;

            if (x2 - x1 == 0) throw new DivideByZeroException("Невозмонжно рассчитать K-коэфициент:\nДеление на ноль");

            this.k_cof = (y2 - y1) / (x2 - x1);
            this.b_cof = (-1) * k_cof * x1 + y1;

            k_cof = Double.Round(k_cof);
            b_cof = Double.Round(b_cof);

        }
        public int CompareTo(LinearFunction line)
        {
            if (line != null)
            {
                int kComparison = line.k_cof.CompareTo(k_cof);
                if (kComparison != 0) return kComparison;
                return line.b_cof.CompareTo(b_cof);
            }
            else throw new ArgumentException();
        }
        private String KcofFormater()
        {
            String temp = k_cof + "x";
            if (k_cof == -1) temp = "-x";
            if (k_cof == 1) temp = "x";
            if (k_cof == 0) temp = "";
            return temp;
        }
        private String BcofFormater()
        {
            if (KcofFormater() == "") return Math.Abs(Convert.ToDouble(b_cof)).ToString();
            else
            {
                if (b_cof > 0) { return " + " + Math.Abs(Convert.ToDouble(b_cof)); }
                if (b_cof < 0) { return " - " + Math.Abs(Convert.ToDouble(b_cof)); }
            }
            return "";
        }
        
        public string GetFormulaText()
        {
            String string_formula;
            string_formula = "y = " + KcofFormater() + " " + BcofFormater();

            return string_formula;
        }
        public static bool IsLinearsParallel(LinearFunction l1, LinearFunction l2)
        {
            double slope_ln1 = (l1.y2 - l1.y1) / (l1.x2 - l1.x1);
            double slope_ln2 = (l2.y2 - l2.y1) / (l2.x2 - l2.x1);

            return slope_ln1 == slope_ln2;
        }
        public static double GetLinearsDegree(LinearFunction l1, LinearFunction l2)
        {
            return Math.Abs(Math.Floor((Math.Atan((l2.k_cof - l1.k_cof) / (1 + (l2.k_cof * l1.k_cof))) * 180) / Math.PI));
        }
    }
}
