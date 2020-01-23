using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11_My_Fibonacci
{
    class Program
    {
             static void Chisla_Fibonacci(int N, out int[] chisla)
        {
            chisla = new int[N + 1];
            chisla[1] = 0; chisla[2] = 1;
            for (int j = 3; j <= N; j++)
                chisla[j] = chisla[j - 2] + chisla[j - 1];
        }
        static int Chislo_Fibonacci(int N)
        {
            int f1 = 0, f2 = 1, fn = 1;
            if (N < 1) return f1;
            if (N == 1) return f2;
            for (int j = 3; j <= N; j++)
            {
                fn = f1 + f2;f1 = f2;f2 = fn;
            }
            return fn;
        }
        static void Main(string[] args)
        {
            int[] fibonacci;int n = 30;
            Chisla_Fibonacci(n, out fibonacci);
            string txt = "";
            for (int i = 1; i <=n ; i++)
            {
                txt += string.Format("{0} ", fibonacci[i]);
            }
            Console.WriteLine(txt);
            Console.WriteLine("f({0})={1}\r\n", n, Chislo_Fibonacci(n));

            double d1, d2;txt = "";
            for (int i = 7; i <= n; i++)
            {
                d1 = (double)fibonacci[i - 1] / (double)fibonacci[i];
                d2 = (double)fibonacci[i] / (double)fibonacci[i-1];
                txt += string.Format("{0}", fibonacci[i]).PadLeft(7);
                txt += string.Format("{0:F9}", d1).PadLeft(15);
                txt += string.Format("{0:F9}\r\n", d2).PadLeft(17);
            }
            Console.WriteLine(txt);
            Console.ReadLine();

        }
    }
}
