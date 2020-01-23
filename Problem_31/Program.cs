using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Problem_31
{
    
        public delegate double Member_of_Numeric_Series(int Index);
    class main_P21
        {
            static double a = 1.7, b = -1.1, c = 0.5, d = -3.4;
            static void Main(string[] args)
            {
                int k1 = 0, k2 = 0, N = 25300;
                double eps = 1.0E-9, dlt = 1.0E-8;

                double summa_N = Sum_of_Number_Series(1, N, Series_N_v01);
                Console.WriteLine(" SN = {0:F12}", summa_N);

                double summa_1 = Sum_of_Number_Series_A(0, eps, Series_1_v01, ref k1);
                Console.WriteLine(" S1 = {0:F12}  k1 = {1}", summa_1, k1);

                double summa_2 = Sum_of_Number_Series_D(1, dlt, Series_2_v01, ref k2);
                Console.WriteLine(" S2 = {0:F12}  k2 = {1}", summa_2, k2);
                Console.ReadKey();
            }
            static double Series_N_v01(int k)
            {
                return (Math.Pow((k + 5.0 / k), (0.25)) / ((Math.Sqrt(5.0 * k) - 3) * (2.0 * k - 7)));
            }
            static double Series_1_v01(int i)
            {
                return ((a / ((i * i + 9.0) * (i - b))) - (b / (Math.Pow((i + 2.0 * a), 3))));
            }
            static double Series_2_v01(int j)
            {
                if ((j % 2) == 0)
                    return ((1.0 * (d - 2.0 * (Math.Pow(j, (-1.0))))) / (Math.Sqrt(j + c) * (j * j + 9.0)));
                else return ((-1.0 * (d - 2.0 * (Math.Pow(j, (-1.0))))) / (Math.Sqrt(j + c) * (j * j + 9.0)));
            }
            public static double Sum_of_Number_Series(int Initial_Index, int Last_Index, Member_of_Numeric_Series Member)
            {
                double global_sum = 0.0;
                for (int k = Initial_Index; k <= Last_Index; k++)
                {
                    global_sum += Member(k);
                }
                return global_sum;
            }
            static double Sum_of_Number_Series_A(int Initial_Index, double Eps, Member_of_Numeric_Series Member, ref int Final_Index)
            {
                double mem_k, pattial_sum, global_sum = 0.0;
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
                    pattial_sum = Sum_of_Number_Series(k, k + K, Member);
                    global_sum += pattial_sum;
                    flag = (Math.Abs(pattial_sum) >= Eps);
                    if (flag) k = k + K + 1;
                } while (flag);
                Final_Index = k + K;
                return global_sum;

            }
            static double Sum_of_Number_Series_D(int Initial_Index, double Delta, Member_of_Numeric_Series Member, ref int Final_Index)
            {
                double mem_k, pattial_sum, global_sum = 0.0;
                int k = Initial_Index; bool flag;
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
                    pattial_sum = Sum_of_Number_Series(k, k + K, Member);
                    global_sum += pattial_sum;
                    flag = (Math.Abs(pattial_sum / global_sum) >= Delta);
                    if (flag) k = k + K + 1;
                } while (flag);
                Final_Index = k + K;
                return global_sum;

            }

        }
    
}
