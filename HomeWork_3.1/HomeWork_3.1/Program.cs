using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите ваш возраст");
            string age1 = Console.ReadLine();
            int age = Convert.ToInt32(age1);
            Console.WriteLine("Введите ваш номер телефона");
            string number1 = Console.ReadLine();
            int number2 = Convert.ToInt32(number1);
            string name1 = String.Format("Вас зовут {0}. Вам {1:## лет}", name, age);
            string now = String.Format("Сегодня {0:D}", DateTime.Now);
            string nowtime = String.Format("Сегодня {0:T}", DateTime.Now);
            string number = String.Format("Ваш номер телефона : {0:+38(0##)###-##-##}", number2);
            string rez = String.Format("{0}\n{1}\n{2}\n{3}\n", name1, now, nowtime, number);
            Console.Write(rez);
            Console.ReadKey();
        }
    }
}
