using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversity
{
    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number;
        public List<string> StudentSubject = new List<string>();
        public Dictionary<string, List<int>> MarkSubjects = new Dictionary<string, List<int>>();
        int num = 1;
        public Student ()
        {
            Console.WriteLine("Введите имя студента");
            FirstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию студента");
            LastName = Console.ReadLine();
            Number = num;
            num += 1;
        }

        public Student(string firstName, string lastName)
        {

            FirstName = firstName;
            LastName = lastName;
            Number = num;
            num += 1;
        }

        public void StudentInfo()
        {
            Console.WriteLine($"{Number}  {FirstName} {LastName}\n");
        }

        public void AddSubject()
        {
            Subjects.AddSubject(StudentSubject);
        }

        public void OutSubject()
        {
            Console.WriteLine("Предметы которые изучает студент");
            Subjects.OutSubjects(StudentSubject);
        }
        void List(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write("{0}  ", i);
            }
        }
        public void OutMarks()
        {
            Console.WriteLine($"Оценки студента {FirstName} {LastName}");
            foreach (var c in MarkSubjects)
            {
                Console.Write("{0} ", c.Key);
                List(c.Value);
                Console.WriteLine();
            }
        }
    }
}
               