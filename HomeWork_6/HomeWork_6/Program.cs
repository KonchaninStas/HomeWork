using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassUniversity;

namespace HomeWork_6
{
    class Program
    {
        static void Main(string[] args)
        {
           Subjects a = new Subjects();
          Student s1 = new Student();
           s1.AddSubject();
            s1.StudentInfo();
            s1.OutSubject();
            Teacher t1 = new Teacher();
            t1.AddSubject();
            t1.TeacherInfo();
            t1.OutSubject();
            t1.Vvod(s1.StudentSubject,s1.MarkSubjects);
            s1.OutMarks();
            Console.ReadKey();
        }
    }
}
