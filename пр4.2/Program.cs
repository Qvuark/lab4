using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        {
            int count = File.ReadAllLines(fileName).Length;
            Student[] students = new Student[count];
            StreamReader sr = new StreamReader(fileName);
            for (int i = 0; i < count; i++)
            {
                students[i] = new Student(sr.ReadLine());
            }
            sr.Close();
            return students;
        }
        static void var13(Student[] studs)
        {
            List<Student> studentsWith5 = new List<Student>();
            foreach (var student in studs)
            {
                if (student.informaticsMark == '5')
                {
                    studentsWith5.Add(student);
                }
            }
            Console.WriteLine("Студенти з найвищим середнім балом з інформатики (5):");
            for(int i=0;i<studentsWith5.Count;i++)
            {
                Console.WriteLine($"{studentsWith5[i].surName} - Середній бал: {studentsWith5[i].averagemark}");
            }
            Console.ReadLine();
        }
        static void RunMenu(Student[] studs)
        {
            var13(studs);
        }

        static void Main(string[] args)
        {
            Student[] studs = ReadData("input.txt");
            RunMenu(studs);
        }
    }
}
