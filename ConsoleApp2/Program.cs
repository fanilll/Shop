using System;

public class LagrangeInterpolation
{
    private double[] xValues;
    private double[] yValues;

    public LagrangeInterpolation(double[] x, double[] y)
    {
        xValues = x;
        yValues = y;
    }

    public double Interpolate(double x)
    {
        double result = 0.0;

        for (int i = 0; i < xValues.Length; i++)
        {
            double term = yValues[i];

            for (int j = 0; j < xValues.Length; j++)
            {
                if (i != j)
                {
                    term *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                }
            }

            result += term;
        }

        return result;
    }
}

public class Program
{
    public static void Main()
    {
        double[] xValues = { 0.27, 0.93, 1.46, 2.11, 2.87 };
        double[] yValues = { 2.60, 2.43, 2.06, 0.25, -2.60 };

        LagrangeInterpolation interpolation = new LagrangeInterpolation(xValues, yValues);

        double x1 = 1.02;
        double x2 = 0.65;
        double x3 = 1.28;

        double result1 = interpolation.Interpolate(x1);
        double result2 = interpolation.Interpolate(x2);
        double result3 = interpolation.Interpolate(x3);

        Console.WriteLine($"Результат при x = {x1}: {result1}");
        Console.WriteLine($"Результат при x = {x2}: {result2}");
        Console.WriteLine($"Результат при x = {x3}: {result3}");
    }
}