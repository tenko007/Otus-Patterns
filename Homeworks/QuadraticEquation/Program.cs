using System;
using System.Collections.Generic;

namespace HW1___QuadraticEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            double discriminant = double.Epsilon / 2;
            double a = 1, c = 0;
            double b = Math.Sqrt(discriminant);

            QuadraticEquation equation = new QuadraticEquation(a, b, c);

            Console.WriteLine($"a = {equation.a}");
            Console.WriteLine($"b = {equation.b}");
            Console.WriteLine($"c = {equation.c}");

            List<double> result = equation.Solve();

            if (result.Count == 0)
                Console.WriteLine("No roots");
            else
            {
                Console.WriteLine("Roots:");
                foreach (double d in result)
                    Console.WriteLine(d);
            }
        }
    }
}
