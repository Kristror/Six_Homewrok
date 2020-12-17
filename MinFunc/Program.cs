using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinFunc
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Домашняя работа Безукладникова Даниила
            ///  Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
            ///  а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
            ///  б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
            ///  в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений.
            ///  Пусть она возвращает минимум через параметр.
            ///  
            Console.WriteLine("Прогрмамма по нахожднию минимума функции");

            Console.WriteLine("Выберите нужную вам функцию:");
            MinFunc min = new MinFunc();
            min.FuncShow();
            int oper;
            Int32.TryParse(Console.ReadLine(), out oper);

            Console.WriteLine("Введите начало отрезка для нахождения минимума функции:");
            int start = 100;
            Int32.TryParse(Console.ReadLine(), out start);

            Console.WriteLine("Введите конец отрезка для нахождения минимума функции:");
            int end = -100;
            Int32.TryParse(Console.ReadLine(), out end);

            Console.WriteLine("Введите шаг для нахождения минимума функции:");
            double step = 1;
            Double.TryParse(Console.ReadLine(), out step);

            min.SaveFunc("data.bin",start, end, step, min.FuncGet(oper));
            double mini = 0;
            List<double> mas = min.Load("data.bin", ref mini);

            Console.WriteLine("Массив полученных значений:");
            for(int i =0; i< mas.Count; i++)
            {
                Console.Write($"{mas[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Минимум функции: {mini}");
            Console.ReadKey();

        }
    }
}
