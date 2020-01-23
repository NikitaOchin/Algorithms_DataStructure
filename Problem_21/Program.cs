using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_21
{
    class main_P21
    {
        static int[][] BCp, BCm;
        static int n, m;
        static double alpha, betta, xz;
        static double[] C;
        static void Main(string[] args)
        {
            n = 5; m = 8; alpha = 0.6; betta = 0.1; xz = -0.45;
            
            double fz = f(xz,2*n-2, m+3, alpha, betta, out C);
            string txt = "";
            for (int j = 0; j < C.Length; j++)
            {
                txt += string.Format(" C[{0}]=", j).PadLeft(9) + string.Format("{0:F3}", C[j]).PadLeft(8) + "\r\n";
            }
            Console.WriteLine(txt);
            Console.WriteLine(string.Format(" fz(xz)={0}", fz)) ;
            Console.ReadLine();
        }
        static double f(double x, int N, int M, double a, double b, out double[] c)
        {
            int k = Math.Max(N, M);
            BinomCoeff_p (M);
            BinomCoeff_m (N);
            c = new double[k + 1];
            for (int i = 0; i <=M; i++)
                c[i] += BCp[M][i] * (-b);
            for (int i = 0; i <= N; i++)
                c[i] += BCm[N][i] * a;

            double summa = 0.0, xj = 1.0;
            for (int j = 0; j < k; j++)
            {
                summa += c[j] * xj; xj *= x;
            }
            return summa;
        }
        static void BinomCoeff_m(int N)
        {
            BCm = new int[N + 1][];
            BCm[0] = new int[1]; BCm[0][0] = 1;
            BCm[1] = new int[2]; BCm[1][0] = 1; BCm[1][1] = 1;
            for (int i = 2; i <= N; i++)
            {
                BCm[i] = new int[i + 1];
                BCm[i][0] = 1; BCm[i][i] = 1;
                for (int j = 1; j <= (i - 1); j++)
                {
                    BCm[i][j] = BCm[i - 1][j - 1] + BCm[i - 1][j];
                }
            }
            for (int j = 1; j <= N; j = j + 2)
            {
                for (int i = j; i <= N; i++)
                {
                    BCm[i][j] = -BCm[i][j];
                }
            }

        }
        static void BinomCoeff_p(int N)
        {
            BCp = new int[N + 1][];
            BCp[0] = new int[1]; BCp[0][0] = 1;
            BCp[1] = new int[2]; BCp[1][0] = 1; BCp[1][1] = 1;
            for (int i = 2; i <= N; i++)
            {
                BCp[i] = new int[i + 1];
                BCp[i][0] = 1; BCp[i][i] = 1;
                for (int j = 1; j <= (i - 1); j++)
                {
                    BCp[i][j] = BCp[i - 1][j - 1] + BCp[i - 1][j];
                }
            }

        }
    }
}
