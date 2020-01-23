using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CLM = Task_41_Matrix_Algebra.Class_Matrix;

namespace Problem_41
{
    class main_41
    { 
        static void Main(string[] args)
        {
            int n;
            double[,] A,B,C;
            StreamWriter SW = new StreamWriter("Problem_41_Rezults.txt") ;
            CLM.Read_Matrix_A("Pr_4.2__Matrix_A__v04.bin",out A,out n);
            CLM.Read_Matrix_A("Pr_4.2__Matrix_B__v04.bin", out B, out n);

            
            SW.WriteLine(CLM.Print_A(A, true, 1, 2, "A"));
            SW.WriteLine(CLM.Print_A(B, true, 1, 2, "B"));

            double alpha = 2.5, betta = -0.8;
            Matrix_C(alpha, betta, A, B, out C);
            SW.WriteLine(CLM.Print_A(C, true, 2, 4, "Matrix C"));

            double C_max=0.0,C_min = 0.0;
            int i_min = -1, j_min = -1, i_max = -1, j_max = -1;
            CLM.Matrix_Max_Min(C, ref C_max, ref i_max, ref j_max,
                ref C_min, ref i_min, ref j_min);
            SW.WriteLine("C_min=C[{0},{1}]={2:F4}", i_min, j_min, C_min);
            SW.WriteLine("C_max=C[{0},{1}]={2:F4}", i_max, j_max, C_max);
        }
        static void Matrix_C(double al, double bt, double[,] A, double[,] B, out double[,] C)
        {
            int n = A.GetLength(0);
            double[,] M1 = new double[n,n];
            double[,] M2 = new double[n, n];
            double[,] H1 = new double[n, n];
            double[,] H2 = new double[n, n];
            CLM.Matrix_Multiply(A,bt , out H1);
            CLM.Matrix_Summ(H1, B, out M1);
            CLM.Matrix_Rotation(M1,out M2,false);

            CLM.Transpose_Matrix(B, out H2);
            CLM.Matrix_Multiply(H2,al,out H1);
            CLM.Matrix_Subtract(H1,A,out H2);

            CLM.Matrix_Rotation(H2,out M1,true);
            CLM.Matrix_Rotation(M1, out H1, true);
            CLM.Matrix_Multiply(M2,H1,out C);
        }
    }
}
