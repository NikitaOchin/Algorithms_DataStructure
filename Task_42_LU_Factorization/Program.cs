using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_42_LU_Factorization
{
    class Program
    {
        public static void LU_Factorization(double[,] A, out double[,] L, out double[,] U, out double det)
        {
            int n = A.GetLength(0);
            L = new double[n, n]; U = new double[n, n];
            for (int j = 0; j < n; j++) U[0, j] = A[0, j];
            det = U[0, 0];
            for (int i = 0; i < n; i++) L[i, 0] = A[i, 0] / A[0, 0];
            double s; int m, k;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    m = Math.Min(i, j) - 1; s = A[i, j];
                    for (k = 0; k <= m; k++) s -= L[i, k] * U[k, j];
                    if (i > j) L[i, j] = s / U[j, j];
                    else U[i, j] = s;
                }
                L[i, i] = 1.0; det *= U[i, i];
            }

        }
        static void Main(string[] args)
        {
        }
    }
}
