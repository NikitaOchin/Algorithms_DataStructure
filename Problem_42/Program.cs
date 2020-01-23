using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLM = Task_41_Matrix_Algebra.Class_Matrix;

namespace Problem_42
{
    class Problem_42
    {
        static void Main(string[] args)
        {
            int n;
            double det_A;
            double[,] A, L, U;
            StreamWriter SW = new StreamWriter("Problem_42_Rezults.txt");
            CLM.Read_Matrix_A("LU__Matrix_A__v04.bin", out A, out n);

            CLM.LU_Factorization(A, out L, out U, out det_A);

            SW.WriteLine(CLM.Print_A(L,true,1,2,"matrix L"));
            SW.WriteLine(CLM.Print_A(U, true, 1, 2, "matrix U"));
            SW.WriteLine(" det_a=  {0:F3}",det_A);

            SW.WriteLine(CLM.Print_A(A, true, 1, 2, "matrix A"));
            CLM.Matrix_Multiply(L,U,out A);
            SW.WriteLine(CLM.Print_A(A, true, 1, 2, "matrix L*U"));
            


        }
        
        
    }
}
