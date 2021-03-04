using System;
using System.Collections.Generic;

namespace algorithms_lab_2
{
    class Program
    {
        public delegate double Function(double x, double y);
        static double Func(double x, double y)
        {
            return y * Math.Cos(x);
        }


        static List<double> Runge_Kutta(Function f, double x0, double y0, double h, int m)
        {
            double k0, k1, k2, k3;
            List<double> result = new List<double>();
            for (int i = 0; i < m; i++)
            {
                k0 = h * f(x0, y0);
                k1 = h * f(x0 + h / 2, y0 + k0 / 2);
                k2 = h * f(x0 + h / 2, y0 + k1 / 2);
                k3 = h * f(x0 + h, y0 + k2);
                result.Add(y0 + (k0 + 2 * k1 + 2 * k2 + k3) / 6);
                x0 = x0 + h;
            }
            return result;
        }


        static List<double> Prediction(Function f, double x0, double y0, double h0, int m)
        {
            List<double> result = new List<double>();
            List<double> X = new List<double>();
            double h = h0 / m;
            X.Add(x0);
            for (int i=1; i<=4; i++)
            {
                X.Add(X[i - 1] + h);
            }
            result = Runge_Kutta(f, x0, y0, h, 5);

            for (int i = 4; i < m ; i++)
            {
                result.Add(result[i] + h / 24 * (55 * f(X[i], result[i - 1]) - 59 * f(X[i - 2], result[i - 2])
                    + 37 * f(X[i - 3], result[i - 3]) - 9 * f(X[i - 4], result[i - 4])));
                X.Add(X[i] + h);
            }
            return result;
        }


        static List<double> Corrector(Function f, double x0, double y0, double h0, int m)
        {
            List<double> result = new List<double>();
            double h = h0 / m;

            result = Runge_Kutta(f, x0, y0, h, m);
            for (int i=2; i < m -1; i++)
            {
                result[i + 1] = result[i] + h / 24 * (9 * result[i + 1] - 19 * result[i] -
                    5 * result[i - 1] + result[i - 2]);
            }
             return result;
        }


        static List<double> Adams(Function f, double x0, double y0, double h0, int m)
        {
            double h = h0 / m;
            double delta1, delta2, delta3;
            List<double> result = new List<double>();
            List<double> X = new List<double>();
            X.Add(x0);
            for (int i = 1; i < 4; i++)
            {
                X.Add(X[i - 1] + h);
            }
            result = Runge_Kutta(f, x0, y0, h, 4);  
            for (int i = 3; i < m; i++)
            {
                delta1 = f(X[i], result[i]) - f(X[i - 1], result[i - 1]);
                delta2 = f(X[i], result[i]) - 2 * f(X[i - 1], result[i - 1]) + f(X[i - 2], result[i - 2]);
                delta3 = f(X[i], result[i]) - 3 * f(X[i - 1], result[i - 1]) + 3 * f(X[i - 2], result[i - 2]) -
                    f(X[i - 3], result[i - 3]);
                X.Add(X[i] + h);
                result.Add(result[i] + h * result[i] + h * h / 2 * delta1 +
                    5 * h * h * h / 12 * delta2 + 3 / 8 * h * h * h * h * delta3);
               
            }
            return result;
        }


        static double Integral(Function f, double x0, double x, double y, int n)
        {
            double integral = 0;
            double h = (x - x0) / n;

            for (int i =0; i <n; i++)
            {
                integral += h * f(x0 + i * h, y);
            }
            return integral;
        }


        static double Approximation(Function f, double x0, double x, double y0, double y, int n)
        {
            double y1 = y0 + Integral(f, x0, x, y, n);
            return y0 + Integral(f, x0, x, y1, n);
        }


        static List<double> ApproximationMethod(Function f, double x0, double y0, double h0, double m) 
        {
            List<double> result = new List<double>();
            List<double> X = new List<double>();
            double h = h0 / m;

            for (double i = x0; i <= h0 + x0; i += h)
            {
                X.Add(i);
            }
            result.Add(y0);
            for (int i = 1; i < X.Count; i++)
            {
                result.Add(Approximation(f, x0, X[i], y0, result[i - 1], 100));
            }
            return result;
        }

        static void Print(List<double> list)
        {
            foreach (var i in list)
            {
                Console.Write(i);
                Console.Write("\t");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Function f = Func;
            Console.WriteLine("y0 = 1\nx0 = 1\nh0 = 2\nm = 5");
            double x0 = 1, y0 = 1, h0 = 2;
            int m = 5;
            List<double> result1, result2, result3, result4, result5 = new List<double>();


            result1 = Runge_Kutta(f, x0, y0, h0, m);

            result2 = Prediction(f, x0, y0, h0, m);

            result3 = Corrector(f, x0, y0, h0, m);

            result4 = Adams(f, x0, y0, h0, m);

            result5 = ApproximationMethod(f, x0, y0, h0, m);
            Print(result1);
            Print(result2);
            Print(result3);
            Print(result4);
            Print(result5);
        }
    }
}
