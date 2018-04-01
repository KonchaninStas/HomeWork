using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите длину рулона");
            string x1 = Console.ReadLine();
            double Lp = Convert.ToDouble(x1);
            Console.WriteLine($"Введите ширину рулона");
            string x2 = Console.ReadLine();
            double Bp = Convert.ToDouble(x2);
            Console.WriteLine($"Введите шаг рисунка");
            string x3 = Console.ReadLine();
            double Lh = Convert.ToDouble(x3);
            Console.WriteLine($"Введите высоту комнаты");
            string x4 = Console.ReadLine();
            double  Lk = Convert.ToDouble(x4);
            Console.WriteLine($"Введите ширину комнаты");
            string x5 = Console.ReadLine();
            double Bk = Convert.ToDouble(x5);
            double Kp = Math.Ceiling ( Bk / Bp);//количество полос по ширине
            double Lpol = (Math.Ceiling(Lk / Lh)*Lh);//длина рулона по высоте комнаты
            double Kpol = Lp / Lpol;//количество полос с одного рулона
            double Lobr1 = Lpol - Lk;//длина обрезков от 1 полосы
            double Lobr = Lp - (Lpol * Kpol) + (Kpol * Lobr1);//длина обрезков с одного рулона
            double K = (Math.Ceiling(Kp / Kpol));//сколько рулонов надо
            double Kpyl = (Lp*K)-(Kp*Lpol); // длина обрезков с всех рулонов(вверх)
            double Lobro = (Lobr1 * Kp) + Kpyl;//Всего длина обрезков
            double Pros = Math.Ceiling((Lobro*100)/(K*Lp));//процент обрезков
            Console.WriteLine($"Нужное количество рулонов обоев = {K}");//выводим количество рулонов
            Console.WriteLine($"Количество полос для поклейки = {Kp}");//выводим количество полос
            Console.WriteLine($"Общая длина обрезков =  {Lobro}");//всего длина обрезков
            Console.WriteLine($"Общий процент обрезков  = {Pros}%" );//процент обрезков
            Console.ReadKey();





        }
    }
}
