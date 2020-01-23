using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_32
{
    class Program
    {
        static double a, b, x1, x2, eps;
        static void Main(string[] args)
        {
            eps = 1.0E-9;
            a = 2.3; b = 3.7; x1 = 2.1; x2 = 5.2;
            Console.WriteLine(" f1({0:F1}) = {1:F10}", x1, f0(x1));
            Console.WriteLine(" f2({0:F1}) = {1:F10}", x2, f0(x2));
            Console.ReadLine();
        }
        static double f0(double x)
        {
            if (x == 0) return 0.0;

            double cos_ax = Math.Cos(a * x), sin_bx = Math.Sin(b * x),
                xz = -1.0 / Math.Sqrt(2.0), r = x * x;
            double pk = 1.0, Ak = cos_ax / Math.Sqrt(Math.PI) + xz * sin_bx / b, summa = Ak;
            for (int k = 1; Math.Abs(Ak) > eps; k++)
            {

                pk = -pk * r / k;
                Ak = (cos_ax / (k * r + Math.Sqrt(Math.PI)) + xz * sin_bx / (k * x + b)) / (2 * k + 1) * pk;
                summa += Ak;
            }
            return summa;
        }

    }
}
