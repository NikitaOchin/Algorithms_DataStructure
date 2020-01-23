using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11
{
    class Program
    {
        static int m = 241, n = 94, K = 114;
        static void Main(string[] args)
        {
            List<int> prime_numbers;
            int A = Eratosphens_I(m, out prime_numbers);
            Console.WriteLine(A);
            int B = Eratosphens_I(n, out prime_numbers);
            Console.WriteLine(B);
            Console.WriteLine(A_divided_B(A, B, K));
            Console.ReadLine();
        }
        static int Eratosphens_I(int prime_index, out List<int> prime_numbers)
        {
            prime_numbers = new List<int>();
            if (prime_index < 1) return 0; prime_numbers.Add(1);
            prime_numbers.Add(2); if (prime_index == 1) return prime_numbers[1];
            prime_numbers.Add(3); if (prime_index == 2) return prime_numbers[2];
            int counter = 2;
            for (int test_number = 5; test_number <= int.MaxValue; test_number += 2)
            {
                int i = 1;
            next_prime_number: i++;
                if (test_number < prime_numbers[i] * prime_numbers[i])
                {
                    prime_numbers.Add(test_number);
                    counter++; if (counter == prime_index) return test_number;

                }
                else
                {
                    if ((test_number % prime_numbers[i]) == 0) continue;
                    else goto next_prime_number;
                }
            }
            return prime_numbers[prime_index];
        }
        static string A_divided_B(decimal A, decimal B, int M)
        {
            if (B == 0) return "Divided by zero";
            string txt = "";
            int F = (int)(A / B);
            txt += string.Format(" {0},", F);
            for (int i = 1; i <= M; i++)
            {
                A = (A - F * B) * 10; F = (int)(A / B);
                txt += string.Format("{0}", Math.Abs(F));
            }
            return txt;
        }
    }
}
