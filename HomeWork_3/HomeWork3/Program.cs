using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Text
    {
        public void Vvod()
        {
        Start:;
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\nВведите проверяемый текст:\n");
            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string s1, s2;
            int i = 0;
            int sum = 0;
            int sum1 = 0;
            for (i = 0; i < words.Length;)
            {
                sum = 0;
                s1 = words[i];
                string[] bas = s1.Split(new char[] { ' ', ',', ':' , ':', ';', '-', '"', '<', '>', '%', '/' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < bas.Length;)
                {
                    s2 = bas[j];
                    sum++;
                    j++;
                }
                if (sum > sum1)
                {
                    sum1 = sum;
                    Console.Clear();
                    Console.WriteLine("Исходный текст:\n");
                    Console.WriteLine(text);
                    Console.WriteLine("\n Предложение в котором больше всего слов:\n");
                    Console.WriteLine(s1);
                }
                i++;
            }        
            Console.WriteLine("\nПроверить что то другое?");
            while (true)
            {
                if (Console.KeyAvailable)//выход с программы
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape:
                            goto End;
                        case ConsoleKey.Enter:
                            goto Start;

                    }
                }
            }
            End:;
        }
     
    }
    class Program
    {
        static void Main(string[] args)
        {
            Text text1 = new Text();
            text1.Vvod();
        }
    }
}
