using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFunc
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Домашняя работа Безукладникова Даниила
            ///   Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double).
            ///   Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
            /// 
            Console.WriteLine("Прогрмамма по выводу таблицы функции");
            Console.WriteLine("Введите значение начальное значение x:");
            double x;
            Double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Введите значение конечное значение x:");
            double x2;
            Double.TryParse(Console.ReadLine(), out x2);

            Console.WriteLine("Введите значение a:");
            double a;
            Double.TryParse(Console.ReadLine(), out a);
            Output outp = new Output();
            Console.WriteLine("Таблица функции a*x^2:");
            outp.Table(outp.Ax, x, x2, a);
            Console.WriteLine("Таблица функцииa*sin(x):");
            outp.Table(outp.aSin, x * -1, x, a);
            Console.ReadKey();
        }
    }
}
