using System;

namespace Algorithms_lab_3
{
    class Program
    {
        class Gauss
        {
            public int row;
            double[,] A, a;
            double[] B, b, X;
            double S;
            public Gauss(int row)
            {
                this.row = row;
                A = new double[row, row];
                a = new double[row, row];

                B = new double[row];
                b = new double[row];
                X = new double[row];
            }
            

            public void FillMatrix()
            {
                Console.WriteLine("Введите коэффициенты и свободные члены");
                for (int i=0; i < row;i++)
                {
                    for (int j =0; j < row; j++)
                    {
                        Console.Write($"A[{i + 1}][{j + 1}]= ");
                        A[i, j] = double.Parse(Console.ReadLine());
                        if (A[i, j] == 0 && i==j)
                        {
                            Console.WriteLine($"A[{j + 1}, {j + 1}] = 0, det A = 0");
                            Environment.Exit(0);
                        }
                        a[i, j] = A[i, j];
                    }
                    Console.Write($"B[{i + 1}]= ");
                    B[i] = double.Parse(Console.ReadLine());
                    b[i] = B[i];
                }
            }


            public void GetResult()
            {
                double coef;
                for (int k =0; k < row; k++)
                {
                    for (int j = k +1; j < row; j++)
                    {
                        coef = A[j, k] / A[k, k];
                        for (int i = k; i< row; i++)
                        {
                            A[j, i] = A[j, i] - coef * A[k, i];
                        }
                        B[j] = B[j] - coef * B[k];
                    }
                }


                for (int k = row -1; k >= 0; k--)
                {
                    coef = 0;
                    
                    for (int j = k ; j < row; j++)
                    {
                        S = A[k, j] * X[j];
                        coef += S;
                    }
                    X[k] = (B[k] - coef) / A[k, k];
                }

            }


            public void ShowResult()
            {
                for (int i =0; i < row; i++)
                {
                    for (int j =0; j <row; j++)
                    {
                        if (a[i, j] >= 0 && j != 0)
                            Console.Write("{0, -1} {1, -4}", "+", $"{a[i, j]}X");
                        else if (a[i, j] < 0)
                            Console.Write("{0, -1} {1, -4}", "-", $"{a[i, j] * (-1)}X");
                        else if (a[i, j] >= 0 && j == 0)
                            Console.Write("{0, -1} {1, -4}", " ", $"{a[i, j]}X");
                    }
                    Console.Write("{0, -1} {1, 3}", "=", $"{b[i]}");
                    Console.WriteLine();
                }
                for (int i=0; i<row; i++)
                {
                    Console.WriteLine($"X[{i}] = {X[i]}");
                }
            }

        }

        class MethodProgonka
        {
            public int row;
            double[,] A;
            double[] a, B, b, X, e;
            public MethodProgonka(int row)
            {
                this.row = row;
                A = new double[row, row];
                a = new double[row];
                B = new double[row];
                b = new double[row];
                X = new double[row];
                e = new double[row];

            }

            public void FillMatrix()
            {
                Console.WriteLine("Введите коэффициенты и свободные члены");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        Console.Write($"A[{i + 1}][{j + 1}]= ");
                        A[i, j] = double.Parse(Console.ReadLine());
                        if (A[i, j] == 0 && i == j)
                        {
                            Console.WriteLine($"A[{j + 1}, {j + 1}] = 0, det A = 0");
                            Environment.Exit(0);
                        }
                    }
                    Console.Write($"B[{i + 1}]= ");
                    B[i] = double.Parse(Console.ReadLine());
                }
            }

            public void GetResult()
            {
                e[0] = A[0, 0];
                a[0] = -A[0, 1] / e[0];
                b[0] = B[0] / e[0];
                for (int i = 1; i < row - 1; i++)
                {
                    e[i] = A[i, i] + A[i, i - 1] * a[i - 1];
                    a[i] = -A[i, i + 1] / e[i];
                    b[i] = (B[i] - A[i, i - 1] * b[i - 1]) / e[i];
                }
                e[row - 1] = A[row - 1, row - 1] + A[row - 1, row - 2] * a[row - 2];
                b[row - 1] = (B[row - 1] - A[row - 1, row - 2] * b[row - 2]) / e[row - 1];

                X[row - 1] = b[row - 1];
                for (int i = row - 2; i >= 0; i--)
                {
                    X[i] = a[i] * X[i + 1] + b[i];
                }
            }


            public void ShowResult()
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        if (A[i, j] >= 0 && j != 0)
                            Console.Write("{0, -1} {1, -4}", "+", $"{A[i, j]}X");
                        else if (A[i, j] < 0)
                            Console.Write("{0, -1} {1, -4}", "-", $"{A[i, j] * (-1)}X");
                        else if (A[i, j] >= 0 && j == 0)
                            Console.Write("{0, -1} {1, -4}", " ", $"{A[i, j]}X");
                    }
                    Console.Write("{0, -1} {1, 3}", "=", $"{b[i]}");
                    Console.WriteLine();
                }
                for (int i = 0; i < row; i++)
                {
                    Console.WriteLine($"X[{i}] = {X[i]}");
                }
            }

        }

        static void Main(string[] args)
        {
           
            Gauss matrix = new Gauss(4);
            matrix.FillMatrix();
            matrix.GetResult();
            matrix.ShowResult();
            

            MethodProgonka matrix2 = new MethodProgonka(4);
            matrix2.FillMatrix();
            matrix2.GetResult();
            matrix2.ShowResult();



        }
    }
}
