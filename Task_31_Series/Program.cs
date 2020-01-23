using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_31_Series
{
    class Main_31
    {
        public delegate double Member_Of_Numeric_Series(int Index);
        static double mem_uk(int k)
        {
            return 1.0 / (2.0 * k + 1.0) / (2.0 * k + 1.0);
        }
        static double mem_vk(int k)
        {
            double b=2.0*k+1.0;
            if ((k % 2) == 0) return 1.0/b/b/b; else return -1.0/b/b/b;
        }
        static double Sum_of_Number_Series_A(int Initial_Index, double Eps, Member_Of_Numeric_Series Member, ref int Final_Index)
        { double mem_k, partial_sum, global_sum = 0.0;
        int k = Initial_Index; bool flag;
        do
        {
            mem_k = Member(k);
            global_sum += mem_k;
            flag = (Math.Abs(mem_k) >= Eps);
            if (flag) k++;
        }
        while (flag);
        int K = k - Initial_Index + 1; k++;
        do
        {
            partial_sum = Sum_of_Number_Series(k, k + K, Member);
            global_sum += partial_sum;
            flag = (Math.Abs(partial_sum) >= Eps);
            if (flag) k = k + K + 1;

        } while (flag);
        Final_Index = k + K; return global_sum;
        }
        
        static double Sum_of_Number_Series_D(int Initial_Index,double Delta,Member_Of_Numeric_Series Member,ref int Final_Index)
        {
            double mem_k,partial_sum,global_sum=0.0;
        int k=Initial_Index;bool flag;
        do
        {
            mem_k = Member(k);
            global_sum += mem_k;
            flag = (Math.Abs(mem_k) >= Delta);
            if (flag) k++;
        }
        while (flag);
        int K = k - Initial_Index + 1; k++;
        do
        {
            partial_sum = Sum_of_Number_Series(k, k + K, Member);
            global_sum += partial_sum;
            flag = (Math.Abs(partial_sum / global_sum) >= Delta);
            if (flag) k = k + K + 1;
        } while (flag);
        Final_Index = k + K; return global_sum;
    }

        static void Main(string[] args)
        {
            string format = "n={0} Sum={1:F14} sum ={2:F14}";
            int N = 25;

            double Summ_1 = Sum_of_Number_Series(1, N, mem_ak);
            double true_1 = true_S1(N);
            Console.WriteLine(format,N,Summ_1,true_1);

            double Summ_2 = Sum_of_Number_Series(0, N, mem_bk);
            double true_2 = true_S2(N);
            Console.WriteLine(format, N, Summ_2, true_2);

            double Summ_3 = Sum_of_Number_Series_A(1,1.0E-10, mem_uk,ref N);
            double true_3 = Math.Pow(Math.PI, 2) / 8.0 - 1.0;
            Console.WriteLine(format, N, Summ_3, true_3);

            double Summ_4 = Sum_of_Number_Series_D(0,1.0E-12,mem_vk,ref N);
            double true_4 = Math.Pow(Math.PI,3)/32.0;
            Console.WriteLine(format, N, Summ_4, true_4);
            Console.ReadLine();
        }
        static double true_S1(int n){
            return 1.0 / (2.0 + 1.0 / n);
        }
        static double true_S2(int n)
        {
            double s2 = n + 1.0;
            if ((n % 2) == 0) return s2; else return -s2;
        }
        static double mem_ak(int k)
        {
            return 1.0/(2.0*k-1.0)/(2.0*k+1.0);
        }
        static double mem_bk(int k) {
            double bk = 2.0 * k + 1.0;
            if ((k % 2) == 0) return bk; else return -bk;
        }
        public static double Sum_of_Number_Series(int Initial_Index, int Last_Index, Member_Of_Numeric_Series Member)
        {
            double global_sum = 0.0;
            for (int k = Initial_Index; k <=Last_Index; k++)
            {
                global_sum += Member(k);
            }
            return global_sum;
        }
    }
}
