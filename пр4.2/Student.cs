using System;
using System.Text;
using System.Linq;

namespace struct_lab_student
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;
        public double averagemark;
        public Student(string lineWithAllData)
        {
            string[] punctuation = { " ", "\t" };
            string[] data = lineWithAllData.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            firstName = data[0];
            surName = data[1];
            patronymic = data[2];
            sex = data[3][0];
            dateOfBirth= data[4];
            mathematicsMark = data[5][0];
            physicsMark = data[6][0];
            informaticsMark = data[7][0];
            scholarship = int.Parse(data[8]);
            averagemark = (mathematicsMark - '0' + physicsMark - '0' + informaticsMark - '0') / 3.0;
        }
    }
}
