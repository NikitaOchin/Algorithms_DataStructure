using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_41_Matrix_Algebra
{
    public class Class_Matrix
    {
        static void Main(string[] args)
        {
        }
        // Считывание и вывод матрицы
        #region
        public static void Read_Matrix_A(string path, out double[,] A, out int n)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Extension == ".txt")
            {
                bool dot_or_comma;
                try { double dot = Convert.ToDouble("0.1"); dot_or_comma = true; }
                catch (FormatException) { dot_or_comma = false; }

                StreamReader rdr = new StreamReader(fi.OpenRead());
                n = Convert.ToInt32(rdr.ReadLine());
                A = new double[n, n];
                string[] numbers; string line;
                for (int i = 0; i < n; i++)
                {
                    line = (rdr.ReadLine()).Trim();
                    if (dot_or_comma) line = line.Replace(",", ".");
                    else line = line.Replace(".", ",");
                    numbers = line.Split(new char[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < n; j++)
                        A[i, j] = Convert.ToDouble(numbers[j]);

                }
                rdr.Close(); return;
            }
            if (fi.Extension == ".bin")
            {
                BinaryReader rdr = new BinaryReader(fi.OpenRead());
                n = rdr.ReadInt32();
                A = new double[n, n];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        A[i, j] = rdr.ReadDouble();
                rdr.Close(); return;
            }
            A = null; n = 0;
        }
        public static string Print_A(double[,] A, bool form, int fs, int fd, string title)
        {
            int ka, n = A.GetLength(1); string txt = "\r\n", frmt;
            if (title != "")
                txt += " " + title + string.Format("  size= {0}\r\n", n);
            if (form)
            {
                frmt = "{0:F" + string.Format("{0}", fd) + "}";
                int max_ka = 0; double a;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a = Math.Abs(A[i, j]);
                        if (a < 10.0) ka = 1; else ka = (int)Math.Ceiling(Math.Log10(a));
                        max_ka = Math.Max(max_ka, ka);
                    }
                }

                ka = fs + 1 + max_ka + 1 + fd;
            }
            else
            {
                frmt = "{0:E" + string.Format("{0}", fd) + "}";
                ka = fs + 1 + 1 + 1 + fd + 1 + 1 + 3;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    txt += string.Format(frmt, A[i, j]).PadLeft(ka);
                }
                txt += "\r\n";

            }
            return txt;
        }
        #endregion

        //Генерация матриц и Элементарные преобразования
        #region
        public static void Identity_Matrix(int N, out double[,] E)
        {
            E = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    E[i, j] = 0.0;
                    E[i, i] = 1.0;
                }
            }
        }
        public static void Test_Matrix(int N, out double[,] T)
        {
            T = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    T[i, j] = 10.0 * (i + 1.0) + j + 1.0;
                }
            }
        }
        public static void Transpose_Matrix(double[,] A)
        {
            int i, j, N = A.GetLength(1); double aij;
            for (i = 0; i < N; i++)
            {
                for (j = i + 1; j < N; j++)
                {
                    aij = A[i, j];
                    A[i, j] = A[j, i];
                    A[j, i] = aij;
                }
            }
        }
        public static void Transpose_Matrix(double[,] A, out double[,] AT)
        {
            int i, j, N = A.GetLength(1); AT = new double[N, N];
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    AT[i, j] = A[j, i];
                }
            }
        }
        public static void Copy_Matrix(double[,] A, out double[,] C)
        {
            int i, j, N = A.GetLength(1); C = new double[N, N];
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    C[i, j] = A[i, j];
                }
            }
        }
        public static void U_Matrix(int N, out double[,] U)
        {
            U = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = i; j < N; j++)
                {
                    U[i, j] = (j - i) + 1.0;
                }
            }
        }
        public static void Matrix_Rotation(double[,] A, out double[,] AR, bool key)
        {
            int i, j, N = A.GetLength(1); AR = new double[N, N];
            if (key)
            {
                for (j = 0; j < N; j++)
                {
                    for (i = 0; i < N; i++)
                    {
                        AR[N - 1 - j, i] = A[i, j];
                    }
                }
            }
            else
                for (i = 0; i < N; i++)
                {
                    for (j = 0; j < N; j++)
                    {
                        AR[j, N - 1 - i] = A[i, j];
                    }
                }
        }
        public static void Matrix_Rotation(double[,] A, bool key)
        {
            int i, j, N = A.GetLength(1); double aij;
            if (key)
            {
                for (i = 0; i < N / 2; i++)
                {
                    for (j = i; j < N - 1 - i; j++)
                    {
                        aij = A[i, j];
                        A[i, j] = A[j, N - 1 - i];
                        A[j, N - 1 - i] = A[N - i - 1, N - j - 1];
                        A[N - i - 1, N - j - 1] = A[N - j - 1, i];
                        A[N - j - 1, i] = aij;
                    }
                }
            }
            else
                for (i = 0; i < N / 2; i++)
                {
                    for (j = i; j < N - 1 - i; j++)
                    {
                        aij = A[i, j];
                        A[i, j] = A[N - j - 1, i];
                        A[N - j - 1, i] = A[N - i - 1, N - j - 1];
                        A[N - i - 1, N - j - 1] = A[j, N - i - 1];
                        A[j, N - i - 1] = aij;
                    }
                }
        }
        #endregion

        // Арифметика + - * Матриц и Векторов
        #region
        public static void Matrix_Summ(double[,] A, double[,] B, out double[,] C)
        {
            int N = A.GetLength(1);
            C = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }

        }
        public static void Matrix_Summ(double[,] A, double[,] B)
        {
            int N = A.GetLength(1);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    A[i, j] += B[i, j];
                }
            }
        }
        public static void Matrix_Subtract(double[,] A, double[,] B, out double[,] C)
        {
            int N = A.GetLength(1);
            C = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }

        }
        public static void Matrix_Subtract(double[,] A, double[,] B)
        {
            int N = A.GetLength(1);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    A[i, j] -= B[i, j];
                }
            }
        }
        public static void Matrix_Multiply(double[,] A, double[,] B, out double[,] C)
        {
            int N = A.GetLength(1);
            C = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                        C[i, j] += A[i, k] * B[k, j];
                }
            }

        }
        public static void Matrix_Multiply(double[,] A, double[,] B)
        {
            int N = A.GetLength(1);
            double[,] arr = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        arr[i, j] += A[i, k] * B[k, j];
                    }

                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    A[i, j] = arr[i, j];
                }
            }

        }
        public static void Matrix_Multiply(double[,] A, double a, out double[,] C)
        {
            int i, j, n = A.GetLength(1); C = new double[n, n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    C[i, j] += a * A[i, j];
                }
            }
        }
        public static void Matrix_Multiply(double[,] A, double a)
        {
            int i, j, n = A.GetLength(1);
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    A[i, j] *= a;
                }
            }
        }
        public static void Matrix_Min_Max(double[,] A, out double max, out int max_i, out int max_j,
                                    out double min, out int min_i, out int min_j)
        {
            int n = A.GetLength(1); max = A[0, 0]; min = A[0, 0]; max_i = 0; max_j = 0; min_i = 0; min_j = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (max <= A[i, j])
                    {
                        max = A[i, j]; max_i = i; max_j = j;
                    }

                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (min >= A[i, j])
                    {
                        min = A[i, j]; min_i = i; min_j = j;
                    }
                }
            }


        }
        public static void Matrix_Max_Min(double[,] A, ref double max, ref int max_i, ref int max_j,
                                    ref double min, ref int min_i, ref int min_j)
        {
            int n = A.GetLength(1); max = A[0, 0]; min = A[0, 0]; max_i = 0; max_j = 0; min_i = 0; min_j = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (max <= A[i, j])
                    {
                        max = A[i, j]; max_i = i; max_j = j;
                    }

                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (min >= A[i, j])
                    {
                        min = A[i, j]; min_i = i; min_j = j;
                    }
                }
            }


        }
        #endregion

        // Разложение Матриц и Определители
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

        // Формирование минора М к элементу aIJ матрицы А
        public static void Minor_1(double[,] A, int I, int J, out double[,] M)
        {
            int i_A, j_A, i_M = 0, j_M, n = (A.GetLength(0) - 1);
            M = new double[n, n];
            for (i_A = 0; i_A <= n; i_A++)
            {
                if (i_A == I) continue;
                j_M = 0;
                for (j_A = 0; j_A <= n; j_A++)
                {
                    if (j_A == J) continue;
                    M[i_M, j_M] = A[i_A, j_A];
                    j_M++;
                }
                i_M++;
            }
        }

        // Рекурсивное вычисление определителя с разложением по элементам 0 столбца
        public static double Determinant_JO(double[,] A)
        {
            int n = (int)A.GetLength(0);
            if (n == 2) return A[0, 0] * A[1, 1] - A[1, 0] * A[0, 1];
            int k, znak = -1; double det = 0.0; double[,] M;
            for (k = 0; k < n; k++)
            {
                znak = -znak; Minor_1(A, k, 0, out M);
                det += znak * A[k, 0] * Determinant_JO(M);
            }
            return det;
        }
        // Рекурсивное вычисление определителя с разложением по элементам 0 строки
        public static double Determinant_IO(double[,] A)
        {
            int n = (int)A.GetLength(0);
            if (n == 2) return A[0, 0] * A[1, 1] - A[1, 0] * A[0, 1];
            int k, znak = -1; double det = 0.0; double[,] M;
            for (k = 0; k < n; k++)
            {
                znak = -znak; Minor_1(A, 0, k, out M);
                det += znak * A[0, k] * Determinant_IO(M);
            }
            return det;
        }
        // Вычисление алгебраического дополнения к элементу аIJ матрицы А
        public static double Cofactor(double[,] A, int I, int J)
        {
            if (A.GetLength(0) == 2)
            {
                if (I == J) return A[0, 0] * A[1, 1];
                else return -A[0, 1] * A[1, 0];
            }
            double[,] minor;
            Minor_1(A, I, J, out minor);
            double A_IJ = Determinant_JO(minor);
            if ((I + J) % 2 == 0) return A_IJ; else return -A_IJ;
        }
        // Вычисление определителя через алгебраические дополнения
        // flag=true для К-й строки, flag=false для К-ого столбца 
        public static double Determinant(double[,] A, int K, bool flag)
        {
            int n = (int)A.GetLength(0);
            if (n == 2) return A[0, 0] * A[1, 1] - A[1, 0] * A[0, 1];
            double determinant = 0.0;
            if (flag)
            {
                for (int j = 0; j < n; j++)
                {
                    determinant += A[K, j] * Cofactor(A, K, j); // po К-ой строке
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    determinant += A[i, K] * Cofactor(A, i, K); // po К-ому столбцу
                }
            }
            return determinant;
        }
    }
}
