using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversity
{
     public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number;
        List<string> TeacherSubject = new List<string>();
        int num = 1;

        public Teacher()
        {
            Console.WriteLine("Введите имя преподователя");
            FirstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию преподователя");
            LastName = Console.ReadLine();
            Number = num;
            num += 1;
        }

        public Teacher(string firstName, string lastName)

        {
            FirstName = firstName;
            LastName = lastName;
            Number = num;
            num += 1;
        }

        public void TeacherInfo()
        {
            Console.WriteLine($"{Number}  {FirstName} {LastName}\n");
        }
        public void AddSubject()
        {
            Subjects.AddSubject(TeacherSubject);
        }
        public void OutSubject()
        {
            Console.WriteLine("Предметы которые ведет преподователь");
            Subjects.OutSubjects(TeacherSubject);
        }
      
        public void Vvod( List<string> list, Dictionary<string, List<int>> dict)
        {
            Subjects.OutSubjects(list);
            Console.WriteLine("Введите название предмета или его номер");
            string str = Console.ReadLine();
            if(Int32.TryParse(str, out int s))
            { 
                int a = Convert.ToInt32(str);
                string str1 = list[a-1];
                List<int> Mark = new List<int>();
                Points.Vvod(Mark);
                dict.Add(str1, Mark);
            }
            else
                foreach (string i in list)
                {
                    if(str==i)
                    { 
                        List<int> Mark = new List<int>();
                        Points.Vvod(Mark);
                        dict.Add(str, Mark);
                    }
                }
        }
    }
}
