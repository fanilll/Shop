using System;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new Complex[,] { { 3, 1 }, { 1, 2 } };
            var b = new Complex[] { 2, 1 };
            var x0 = new Complex[] { 0, 0 };

            var epsilon = 1e-5;
            var maxIterations = 100;

            var x = Iterate(A, b, x0, epsilon, maxIterations);

            Console.WriteLine($"Решение: {string.Join(", ", x)}");
        }

        static Complex[] Iterate(Complex[,] A, Complex[] b, Complex[] x0, double epsilon, int maxIterations)
        {
            var x = x0;
            var iterations = 0;
            var error = double.PositiveInfinity;

            while (error > epsilon && iterations < maxIterations)
            {
                var xNew = Multiply(A, x).Add(b);
                error = VectorNorm(xNew.Select((t, i) => t - x[i]).ToArray());
                x = xNew;
                iterations++;
            }

            return x;
        }

        static Complex[] Multiply(Complex[,] A, Complex[] x)
        {
            var result = new Complex[A.GetLength(0)];
            for (var i = 0; i < result.Length; i++)
            {
                var row = A.GetRow(i);
                for (var j = 0; j < row.Length; j++)
                {
                    result[i] += row[j] * x[j];
                }
            }
            return result;
        }

        static double VectorNorm(Complex[] x)
        {
            double sum = 0;
            foreach (var c in x)
            {
                sum += c.Real * c.Real + c.Imaginary * c.Imaginary;
            }
            return Math.Sqrt(sum);
        }
    }
}