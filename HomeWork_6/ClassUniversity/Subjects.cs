using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversity
{
  public  class Subjects
    {
     static public void AddSubject(List<string> list)
        {
            Console.WriteLine($"Введите предметы\nДля выхода нажмите X");
            while (true)
            {
                    string str = Console.ReadLine();
                if(str=="X"||str=="x"||str == "х" || str == "Х"  )
                {
                    break;
                }
                    list.Add(str);
                }
        }
        
        static public void OutSubjects(List<string> list)
        {
            int j = 1;
            foreach (string i in list)
            {  
                Console.WriteLine($"{j}  {i}");
                j += 1;
            }
            Console.WriteLine($"\n");
        }
    }
}
