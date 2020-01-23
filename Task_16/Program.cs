using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_16
{
    class Program
    {
        //первый
        static long Factorial(long n)
        {
            if (n == 0) return 1;
            long F = 1, i = 1;
            while (i <= n) { F *= i; i++; } return F;
        }
        //Второой метод Факториала через рекрсию
        static int factorial(int n)
        {
            if (n == 0) return 1; return factorial(n - 1) * n;

        }
        static void Main(string[] args)
        {
            int n = 21;
            Console.WriteLine("  int {0}! = {1}", n, factorial(n));
            Console.WriteLine("  int.max = {0}\r\n", int.MaxValue);
            Console.WriteLine("  long {0}! = {1}", n, Factorial(n));
            Console.WriteLine("  long.max = {0}\r\n", long.MaxValue);
            Console.ReadLine();
        }
    }
}
