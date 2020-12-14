using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFunc
{
    class Program
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
        static void Main(string[] args)
        {
            ///
            /// Домашняя работа Безукладникова Даниила
            ///   Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double).
            ///   Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
            /// 
            Console.WriteLine("Прогрмамма по выводу таблицы функции");
            Console.WriteLine("Введите значение x:");
            double x;
            Double.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Введите значение a:");
            double a;
            Double.TryParse(Console.ReadLine(), out a);
            Output outp = new Output();
            Console.WriteLine("Таблица функции a*x^2:");
            outp.Table(outp.Ax, x * -1, x, a);
            Console.WriteLine("Таблица функцииa*sin(x):");
            outp.Table(outp.aSin, x * -1, x, a);
            Console.ReadKey();
        }
    }
}
