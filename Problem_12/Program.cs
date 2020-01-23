using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_12
{
    class Program
    {
                static void Factorial(long k, long n, long a, long b, long m, long l, out long A, out long B)
                {
                    int i = 1;
                    long peremen1 = k;
                    k = 1;
                    while (i <= peremen1)
                    {
                        k = k * i;
                        i++;
                    }
                    Console.WriteLine("k!===== {0}", k);

                    i = 1;
                    peremen1 = n;
                    n = 1;
                    while (i <= peremen1)
                    {
                        n = n * i;
                        i++;
                    }
                    Console.WriteLine("n!===== {0}", n);

                    peremen1 = m;
                    i = 1;
                    m = 1;
                    while (i <= peremen1)
                    {
                        m*= i;
                        i++;
                    }
                    Console.WriteLine("m !===== {0}", m);

                    i = 1;
                    peremen1 = l;
                    l = 1;
                    while (i <= peremen1)
                    {
                        l = l * i;
                        i++;
                    }
                    Console.WriteLine("l!===== {0}", l);

                    A = (13*l-a*k);
                    B = b*m-a * n;
        }
                static void Euclidean_Algoritm_B(long A, long B)
                {
                    long NOD = A;
                    long poc = B;
                    while (poc != 0)
                    {
                        poc = NOD % (NOD = poc);
                    }
                    A = A / NOD;
                    B = B / NOD;
                    Console.WriteLine("NOD == {0} ~A== {1} ~B == {2}", NOD, A, B);
                }
                static void Main(string[] args)
                {
                    long A;
                    long B;
                    int k = 6; int n = 12; int m = 15; int l = 9; int a = 45; int b = 18;
                    Factorial(k, n, a, b, m, l, out A, out B);
                    Console.WriteLine("A={0}; B={1}", A, B);
                    Euclidean_Algoritm_B(A, B);
                    Console.ReadLine();
                }
    }
}
