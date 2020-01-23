using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_13_My_Prime_Numbers
{
    class Main_13
    {
        static List<int> Prime_Numbers;
        static void Erastophenes_M(int prime_maxi, out List<int> prime_numbers)
        {
            prime_numbers = new List<int>();
            if (prime_maxi < 1) return;
            prime_numbers.Add(1); prime_numbers.Add(2); prime_numbers.Add(3);
            if (prime_maxi < 5) return;
            for (int test_number = 5; test_number <= prime_maxi; test_number += 2)
            {
                int i = 1;
            next_prime_number: i++;
                if (test_number < prime_numbers[i] * prime_numbers[i])
                {
                    prime_numbers.Add(test_number); continue;

                }
                else
                {
                    if ((test_number % prime_numbers[i]) == 0) continue;
                    else goto next_prime_number;
                }
            }
        }
        static int Eratosphens_I(int prime_index,out List<int> prime_numbers)
        {
            prime_numbers = new List<int>();
            if (prime_index < 1) return 0; prime_numbers.Add(1);
            prime_numbers.Add(2);if (prime_index == 1) return prime_numbers[1];
            prime_numbers.Add(3);if (prime_index == 2) return prime_numbers[2];
            int counter = 2;
            for (int test_number = 5; test_number <= int.MaxValue; test_number +=2)
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
        static void Main(string[] args) 
        {
            string txt = "";
            Erastophenes_M(101, out Prime_Numbers);
            for (int j = 1; j < Prime_Numbers.Count; j++)
            {
                txt += string.Format(" {0}",Prime_Numbers[j]);
            }
            Console.WriteLine(txt + "\r\n");
            Console.WriteLine(" {0}", Eratosphens_I(200, out Prime_Numbers));
            Console.ReadLine();
        }
    }
}
