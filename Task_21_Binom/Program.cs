using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_21_Binom
{
    class Main_21
    {
        static int[][] BCp;
        static int[][] BCm;
        static void Main(string[] args)
           
        {
            BinomCoeff_p (10);ToPrint (BCp);
            //Console.WriteLine(" {0:F8}", F_BCp(3, 0.5));
            //Console.WriteLine(" {0:F8}", test1(3, 0.5));
            //Console.WriteLine("  {0}  {1}", Cnj(9, 3), Cnj(9, 7));
            Console.WriteLine(" {0:F12}", F_BCp(5, 0.37));
            Console.WriteLine(" {0:F12}", test1(5, 0.37));
            Console.WriteLine(" {0:F12}", f_plus(5, 0.37));

            BinomCoeff_m(10); ToPrint(BCm);
            Console.WriteLine(" {0:F14}", F_BCm(7, 0.16));
            Console.WriteLine(" {0:F14}", test2(7, 0.16));
            Console.WriteLine(" {0:F14}", f_mins(7, 0.16));
            Console.ReadLine();
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
            for (int j = 1; j <= N; j=j+2)
            {
                for (int i = j; i <= N;i++ )
                {
                    BCm[i][j] = -BCm[i][j];
                }
            }

        }


        static double F_BCm(int n, double x)
        {
            double binom = 0.0, xj = 1.0;
            for (int j = 0; j <= n; j++)
            {
                binom += BCm[n][j] * xj; xj *= x;
            }
            return binom;
        }
        static double f_mins(int n, double x)
        {
            double binom = 1.0, xj = 1.0;
            for (int j = 1; j <= n; j++)
            {
                xj *= -x * (n + 1 - j) / j;
                binom += xj;
            }
            return binom;
        }
        static double test2(int n, double x)
        {
            return Math.Pow((1.0 - x), (double)n);
        }

        static double f_plus(int n, double x)
        {
            double binom = 1.0, xj = 1.0;
            for (int j = 1; j <=n; j++)
            {
                xj *= x * (n + 1 - j) / j;
                binom += xj;
            }
            return binom;
        }
        static int Cnj(int n,int j)
    {
        if(j>n-j)j=n-j;
        int C = 1;
        n++;
        for (int J = 1; J <= j; J++)
        {
            C = C * (n - J) / J;
        }
        return C;
    }
        static double test1(int n, double x)
        {
            return Math.Pow((1.0+x),(double)n);
        }
        static double F_BCp(int n, double x)
        {
            double binom = 0.0, xj = 1.0;
            for (int j = 0; j <= n; j++)
            {
                binom += BCp[n][j] * xj; xj *= x;
            }
            return binom;
        }
        static void BinomCoeff_p(int N)
        {
            BCp = new int[N + 1][];
            BCp[0] = new int[1]; BCp[0][0] = 1;
            BCp[1] = new int[2]; BCp[1][0] = 1; BCp[1][1] = 1;
            for (int i = 2; i <=N; i++)
            {
                BCp[i] = new int[i + 1];
                BCp[i][0] = 1; BCp[i][i] = 1;
                for (int j = 1; j <=(i-1); j++)
                {
                    BCp[i][j] = BCp[i - 1][j - 1] + BCp[i - 1][j];
                }
            }
        
        }
        
        static void ToPrint(int[][] table)
        {
            string txt = "";
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j <=i; j++)
			{
			   txt += string.Format("{0}", table[i][j]).PadLeft(5);           
            }
            txt += "\r\n";
            }
        Console.Write(txt);
        }
        
    }
}
