using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversity
{
    class Points
    {
      public  static int Point
        {  
        get
            {
                return points;
            }
        set
            {
                if (value<6 & value>1)
                {
                    points = value;
                }
                else
                {
                    Console.WriteLine("Оценка введена некоректно");
                }
            }
        }
         static int points;
        
        void NamePoint(int Point, out string NameP)
        {
            switch (Point)
            { 
                case 1:
                    NameP = "F - неудовлетворительно";
                break;
            case 2:
                    NameP = "D - достаточно";
                break;
            case 3:
                    NameP = "C - хорошо";
                break;
            case 4:
                    NameP = "B - очень хорошо ";
                break;
            case 5:
                    NameP = "A - отлично";
                break;
                default:
                    NameP = "   ";
                    break;
            }
        }
        static public void  Vvod( List<int> list)
        {
            Console.WriteLine("Введите оценки");
            while (true)
            {
                string str = Console.ReadLine();
           if(!Int32.TryParse(str,out int s))
                {
                    break;
                        }
                Point = Convert.ToInt32(str);
                list.Add(Point);
            }     
        }
    }

}
