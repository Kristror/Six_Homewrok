﻿using System;
using System.Collections.Generic;
using System.IO;

namespace MinFunc
{
    partial class Program
    {
        public class MinFunc
        {
            /// <summary>
            /// массив делегатов
            /// </summary>
            Dictionary<string,F> functions = new Dictionary<string, F>();

            public MinFunc()
            {
                this.functions.Add("x + 10x - 15", FX1);
                this.functions.Add("x^2 - 50x + 10", FX2);
                this.functions.Add("x^2 + 2x + 5", FX3);
            }
           
            public double FX1(double x)
            {
                return x + 10 * x - 15;
            }
            public double FX2(double x)
            {
                return x * x - 50 * x + 10;
            }
            public double FX3(double x)
            {
                return x * x + 2 * x + 5;
            }

            public delegate double F (double x);
            public void SaveFunc(string fileName, double a, double b, double h, F Func)
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                double x;
                double y;
                if (a < b)
                {
                    x = a;
                    y = b;
                }
                else
                {
                    x = b;
                    y = a;
                }
                while (x <= y)
                {
                    bw.Write(Func(x));
                    x += h;;
                }
                bw.Close();
                fs.Close();
            }
            public List<double> Load(string fileName, ref double min)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                min = double.MaxValue;
                List<double> result = new List<double>();
                for (int i = 0; i < fs.Length / sizeof(double); i++)
                {
                    result.Add(bw.ReadDouble());
                    if (result[i] < min) min = result[i];
                }
                bw.Close();
                fs.Close();
                return result;
            }

            public void FuncShow()
            {
                int i = 1;
                foreach(var fun in functions)
                {
                    Console.WriteLine($"{i}) {fun.Key}");
                    i++;
                }
            }
            /// <summary>
            /// Возвращает нужный метод в случае провала поиска возвращает первый
            /// </summary>
            /// <param name="f"></param>
            /// <returns></returns>
            public F FuncGet(int f)
            {
                int i = 1;
                    ;
                foreach (var fun in functions)
                {
                    if (f == i) return fun.Value;
                    i++;
                }
                return new F(FX1);
            }
        }
    }
}
