using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLM = Task_41_Matrix_Algebra.Class_Matrix;

namespace Problem_43
{
    class Program
    {
        static int ni;
        static int nj;
        static void Main(string[] args)
        {
            ni = 5; nj = 2;
            Test_Cofactor("Pr_4.3_A_v04.txt", ni - 1, nj - 1);
        }
        static void Test_Cofactor(string file, int I, int J)
        {
            string txt;double det_A;
            StreamWriter SW = new StreamWriter("Problem_43_Rezults.txt");
            double[,] A;int i, j, n;
            CLM.Read_Matrix_A(file, out A, out n);

            for (j = 0; j <n; j++)
            {
                txt = string.Format("  A[{0},{1}]=", I + 1, j + 1);
                txt += string.Format("  {0}", CLM.Cofactor(A,I,j)).PadLeft(9);
                SW.WriteLine(txt);
            }
            det_A = CLM.Determinant(A, I, true);
            SW.WriteLine("   Determimant(A,  {0}, true)= {1}\r\n",I,det_A);

            for (i = 0; i < n; i++)
            {
                txt = string.Format("  A[{0},{1}]=", i + 1, J + 1);
                txt += string.Format("  {0}", CLM.Cofactor(A, i, J)).PadLeft(9);
                SW.WriteLine(txt);
            }
            det_A = CLM.Determinant(A, J, false);
            SW.WriteLine("   Determimant(A,  {0}, false)= {1}\r\n", J, det_A);
            SW.Close();

        }
    }
}
