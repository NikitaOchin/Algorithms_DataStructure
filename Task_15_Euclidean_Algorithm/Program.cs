using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_15_Euclidean_Algorithm
{
    class Program
    {   static int Euclidean_Algorithm_A(int a, int b)
        {
            if ((a == 0) && (b == 0)) return 1;
            if (a * b == 0) return (a + b);
            a = Math.Abs(a);b = Math.Abs(b);
            while (a != b)
            {
                if (a > b) a = a - b; else b = b - a;
            }
            return a;
        }
        static int Euclidean_Algorithm_B(int a, int b)
        {
            if ((a == 0) && (b == 0)) return 1;
            a = Math.Abs(a); b = Math.Abs(b);
            while ((a != b)&&(b!=0))
            {
                if (a > b) a = a % b; else b = b % a;
            }
            return (a+b);
        }
        static void Chisla_Fibonacci(int N, out long[] chisla)
        {
            chisla = new long[N + 1];
            chisla[1] = 1; chisla[2] = 1;
            for (int j = 3; j <= N; j++)
                chisla[j] = chisla[j - 2] + chisla[j - 1];
        }
        static void Main(string[] args)
        {
            Console.WriteLine(" {0}", Euclidean_Algorithm_A(45, 150));
            Console.WriteLine(" {0}", Euclidean_Algorithm_B(-33, -121));
            long[] Fibonacci; Chisla_Fibonacci(92, out Fibonacci);
            int n = 39, m = 91;
            int k = Euclidean_Algorithm_A(n, m);
            long NOD_F = Euclidean_Algorithm_B(Fibonacci[n], Fibonacci[m]);
            Console.WriteLine(" Fibonacci[{0}]={1}", n, Fibonacci[n]);
            Console.WriteLine(" Fibonacci[{0}]={1}\r\n", m, Fibonacci[m]);
            Console.WriteLine(" k=NOD(n,m)={0}", k);
            Console.WriteLine(" Fibonacci[{0}]={1}", k, Fibonacci[k]);
            Console.ReadLine();
        }
        static long Euclidean_Algorithm_A(long a, long b)
        {
            if ((a == 0) && (b == 0)) return 1;
            if (a * b == 0) return  (a + b);
            a = Math.Abs(a); b = Math.Abs(b);
            while (a != b)
            {
                if (a > b) a = a - b; else b = b - a;
            }
            return a;
        }
        static long Euclidean_Algorithm_B(long a, long b)
        {
            if ((a == 0) && (b == 0)) return 1;
            a = Math.Abs(a); b = Math.Abs(b);
            while ((a != b) && (b != 0))
            {
                if (a > b) a = a % b; else b = b % a;
            }
            return (a + b);
        }
    }
}
