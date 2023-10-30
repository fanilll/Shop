using System;

class LagrangeInterpolation
{
    static double[] x = { 0.27, 0.93, 1.46, 2.11, 2.87 };
    static double[] y = { 2.60, 2.43, 2.06, 0.25, -2.60 };

    static double Calculate(double x)
    {
        double result = 0;
        for (int i = 0; i < x.Length; i++)
        {
            double L = 1;
            for (int j = 0; j < x.Length; j++)
            {
                if (i != j)
                    L *= (x - x[j]) / (x[i] - x[j]);
            }
            result += y[i] * L;
        }
        return result;
    }

    public static void Main(string[] args)
    {
        double x1 = 1.02;
        double x2 = 0.65;
        double x3 = 1.28;

        Console.WriteLine(Calculate(x1));
        Console.WriteLine(Calculate(x2));
        Console.WriteLine(Calculate(x3));
    }
}