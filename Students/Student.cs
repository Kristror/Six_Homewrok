using System;
using System.Collections.Generic;
using System.IO;

namespace Students
{
    partial class Program
    {
        class Student
        {
            public string lastName;
            public string firstName;
            public string group;
            public int course;
            int age;
            public Student()
            {

            }
            public Student(string lastName, string firstName, string group, int course, int age)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.group = group;
                this.course = course;
                this.age = age;
            }
            public List<Student> ReadStuds(string path)
            {
                List<Student> result = new List<Student>();
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path);

                    while (!sr.EndOfStream)
                    {
                        string[] str = sr.ReadLine().Split(' ');
                        result.Add(new Student(str[0], str[1], str[2], int.Parse(str[3]), int.Parse(str[4])));
                    }
                    sr.Close();
                    return result;
                } else return result;
            }
            public int CountCourse(List<Student> students, int course)
            {
                int count = 0;
                foreach (Student stud in students)
                {
                    if (course == stud.course) count++;
                }
                return count;
            }
            /// <summary>
            /// Сортирует массив: true - по возрастанию, true - по убыванию
            /// </summary>
            /// <param name="stud">массив студентов</param>
            /// <param name="type">true - по возрастанию, true - по убыванию</param>
            public void SortAge(ref List<Student> stud, bool type)
            {
                for (int i = 0; i < stud.Count - 1; i++)
                {
                    for (int j = i + 1; j < stud.Count; j++)
                    {

                        if (type)
                        {
                            if (stud[i].age > stud[j].age)
                            {
                                var temp = stud[i];
                                stud[i] = stud[j];
                                stud[j] = temp;
                            }
                        }
                        else
                        {
                            if (stud[i].age < stud[j].age)
                            {
                                var temp = stud[i];
                                stud[i] = stud[j];
                                stud[j] = temp;
                            }
                        }
                    }
                }
            }
            public List<Student> SortCourseAge(List<Student> stud)
            {
                List<Student> result = new List<Student>();
                for (int i = 0; i < stud.Count - 1; i++)
                {
                    for (int j = i + 1; j < stud.Count; j++)
                    {
                        if (stud[i].course < stud[j].course)
                        {
                            var temp = stud[i];
                            stud[i] = stud[j];
                            stud[j] = temp;
                        }
                    }
                }
                List<Student> tempo = new List<Student>();
                for (int i = 1; i < stud.Count - 1; i++)
                {
                    if(stud[i-1].course == stud[i].course)
                    {
                        tempo.Add(stud[i]);
                    } else
                    {
                        Student st = new Student();
                        st.SortAge(ref tempo, false);
                        result.AddRange(tempo);
                        tempo.Clear();
                        tempo.Add(stud[i]);
                    }
                }
                return result;
            }
            public Dictionary<int, int> Contunt18_20 (List<Student> studs)
            {
                Dictionary<int, int> list = new Dictionary<int, int>();
                foreach (var student in studs)
                {
                    if((student.age >= 18)&&(student.age < 20))
                    {
                        if (!list.ContainsKey(student.course))
                        {
                            list.Add(student.course, 1);
                        }
                        else
                        {
                            list[student.course]++; 
                        }
                    }
                }
                return list;
            }
            
            public delegate bool check(Student stud);
            public int Count(List<Student> studs, check func)
            {
                int count = 0;
                foreach (var student in studs)
                {
                    if (func(student)) count++;
                }
                return count;
            }
            public string StudentToString
            {
                get{
                return ($"Фамилия: {this.lastName, -15} имя: {this.firstName, -10}  факульет: {this.group, -4} курс: {this.course, -1} возраст: {this.age,-2} лет.");
                }
            }
            public void Print(List<Student> students)
            {
                foreach(var stud in students)
                {
                    Console.WriteLine(stud.StudentToString);
                }
            }
        }        
    }
}
