using System;

namespace OutFunc
{
    partial class Program
    {
        class Output
        {
            public delegate double Func(double x, double a);
            public void Table(Func F, double x, double b, double a)
            {
                Console.WriteLine("----- X ----- Y -----");
                while (x <= b)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x,a));
                    x += 1;
                }
                Console.WriteLine("---------------------");
            }
            public double Ax(double x, double a)
            {
                return a * x * x;
            }
            public double aSin(double x, double a)
            {
                return a * Math.Sin(x);
            }

        }
    }
}
