using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Numbers
{
    class Program
    {
        struct Composite_Number
        {
            public List<int> prime_numbers, prime_powers;
            public int residual; private int composite_value;
        public Composite_Number(int composite_number,int prime_maxi)
        {
            composite_value=composite_number;
            Erastophenes_M(prime_maxi,out prime_numbers);
            prime_powers=new List <int>();
            for(int i=0;i<prime_numbers.Count;i++)prime_powers.Add(0);
            residual=1;
            for(int k=1; k<prime_numbers.Count;k++)
            {
                while(composite_number%prime_numbers[k]==0)
                {composite_number=composite_number/prime_numbers[k];prime_powers[k]++;}
                if(composite_number==1)return;
            }
            residual=composite_number;
            }
        public string ToPrint()
        {
            if (composite_value == 1) return (" 1 = 1 ");
            string txt = string.Format(" {0} = ", composite_value);
            for (int i = 1; i < prime_numbers.Count; i++)
            {
                for (int j = 1; j <= prime_powers[i]; j++)
                    txt += string.Format("{0}*", prime_numbers[i]);
            }
            if (residual != 1) return (txt + string.Format("{0}", residual));
            else return txt.Substring(0,txt.Length-1);
        }
        }

        static void Main(string[] args)
        {
            Composite_Number CN;
            int number = 13785288, maxi = 101;
            CN=new Composite_Number(number,maxi);
            Console.WriteLine(CN.ToPrint());
            Console.ReadLine();
        }
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
    }
}
