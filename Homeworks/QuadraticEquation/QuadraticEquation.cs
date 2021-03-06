using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___QuadraticEquation
{
    public class QuadraticEquation
    {
        public readonly double a, b, c;
        public QuadraticEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public List<double> Solve()
        {
            CheckRules();

            List<double> result = new List<double>();
            double discriminant = Discriminant();

            if (discriminant.CompareTo((double)0) >= 0)
                result.Add((-b + Math.Sqrt(discriminant)) / 2 * a);

            if (discriminant.CompareTo((double)0) > 0)
                result.Add((-b - Math.Sqrt(discriminant)) / 2 * a);

            return result;
        }

        private void CheckRules()
        {
            if (a.Equals(0)) throw new ArgumentOutOfRangeException();

            if (a is double.NaN) throw new ArgumentOutOfRangeException();
            if (b is double.NaN) throw new ArgumentOutOfRangeException();
            if (c is double.NaN) throw new ArgumentOutOfRangeException();

            if (double.IsInfinity(a)) throw new ArgumentOutOfRangeException();
            if (double.IsInfinity(b)) throw new ArgumentOutOfRangeException();
            if (double.IsInfinity(c)) throw new ArgumentOutOfRangeException();
        }

        public double Discriminant()
        {
            return b*b - 4*a*c;
        }
    }
}
