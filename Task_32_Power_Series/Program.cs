using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_32_Power_Series
{
    class Main_32
    {
        static double eps;
        static void Main(string[] args)
        {
            eps = 1.0E-20;
        }
        static double MySin(double x)
        {
            if (x == 0) return 0.0;
            double sin = x, pk = x, x2 = 0.5 * x;
            for (int k = 2; Math.Abs(pk) > eps; k++)
            {
                pk = -pk * (x2 / (k - 1.0)) * (x2 / (k - 0.5)); sin += pk;
            }
            return sin;
        }
        static double MyCos(double x)
        {
            if (x == 0) return 1.0;
            double cos = 1.0, pk = 1.0, x2 = 0.5 * x;
            for (int k = 2; Math.Abs(pk) > eps; k++)
            {
                pk = -pk * (x2 / (k - 0.5)) * (x2 / k); cos += pk;
            }
            return cos;
        }
    }
}
