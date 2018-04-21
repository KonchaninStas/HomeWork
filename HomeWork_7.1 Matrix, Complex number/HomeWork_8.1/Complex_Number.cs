using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8._1
{
    class Complex_Number
    {
        public int X
        {
        get
            {
                return x;
            }
               set
            {
                x = value;
            }
                }

        public int Y
         {
        get
            {
                return y;
            }
    set
            {
                y = value;
            }
                }
        private int x;
        private int y;


        public override string ToString()
        {
            if (y > 0)
            {
                return ($"{x}+{y}*i");
            }
            else if (y < 0)
            {
                return ($"{x}{y}*i");
            }
            else
                return ($"{x}");

            
        }
        public Complex_Number()
        {
            while(true)
            {
                Console.WriteLine("Введите действительную часть");
                string str = Console.ReadLine();
            if (Int32.TryParse(str,out int a))
            {
                x = Convert.ToInt32(str);
                    break;
            }
            else
                    Console.WriteLine("Введите мнимую часть");
            }
            while (true)
            {
                Console.WriteLine("Введите целое число");
                string str1 = Console.ReadLine();
                if (Int32.TryParse(str1, out int b))
                {
                    y = Convert.ToInt32(str1);
                    break;
                }
                else
                    Console.WriteLine("Введите целое число");
            }
        }

        public Complex_Number(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public static bool operator !=(Complex_Number a, Complex_Number b)
        {
       
            if ((a.x != b.x) || (a.y != b.y))
            {
                return true;
            }
            else
                
            return false;
        }

        public static  bool operator ==(Complex_Number a, Complex_Number b)
        {
          
            if ((a.x == b.x) & (a.y == b.y))
            {
                return true;
            }
            else
                return false;

        }
        public static   Complex_Number operator +(Complex_Number a, Complex_Number b)
        {
            
            Complex_Number result = new Complex_Number();
            result.x = a.x + b.x;
            result.y = a.y + b.y;
            return result;
        }
        public static Complex_Number operator -(Complex_Number a, Complex_Number b)
        {
           
            Complex_Number result = new Complex_Number();
            result.x = a.x - b.x;
            result.y = a.y - b.y;
            return result;
        }
        public static Complex_Number operator *(Complex_Number a, Complex_Number b)
        {

            Complex_Number result = new Complex_Number();
            result.x = a.x * b.x - a.y * b.y;
            result.y = a.x * b.y + b.x + a.y;
            return result;
        }



    }
}
