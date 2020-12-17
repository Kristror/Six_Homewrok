using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Домашняя работа Безукладникова Даниила
            ///   Переделать программу «Пример использования коллекций» для решения следующих задач:
            ///   а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
            ///   б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
            ///   в) отсортировать список по возрасту студента;
            ///   г) *отсортировать список по курсу и возрасту студента;
            ///   д) разработать единый метод подсчета количества студентов по различным параметрам выбора с помощью делегата и методов предикатов.
            /// 
            Console.WriteLine("Программа по работе со студентами");
            Student st = new Student();
            List<Student> list = st.ReadStuds("students.txt");
            Console.WriteLine("Все студенты:");
            st.Print(list);

            int stud56 = st.CountCourse(list, 5) + st.CountCourse(list, 6);
            Console.WriteLine($"Всего студентов на 5 и 6 курсе: {stud56}");

            Dictionary<int, int> stud1820 = st.Contunt18_20(list);
            foreach(var elem in stud1820)
            {
                Console.WriteLine($"На {elem.Key} курсе {elem.Value} учеников от 18 до 20");
            }

            Console.WriteLine("Все студенты отсортированные по возрасту:");
            st.SortAge(ref list, false);
            st.Print(list);

            Console.WriteLine("Все студенты по курсу и возрасту студента:");
            list = st.SortCourseAge(list);
            st.Print(list);

            int count = st.Count(list, x => x.group == "ФАМ");
            Console.WriteLine($"Всего студентов на факультете ФАМ: {count}");

            Console.ReadKey();
        }
    }
}
