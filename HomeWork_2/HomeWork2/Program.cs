using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HomeWork2
{

    public class Game
    {
        int left = 15;
        int shet;
        string str = "----------";
        public void Stena()
        {
            Console.SetWindowSize(70, 30);//ширина и высота окна
            Console.BufferWidth = 70;//ширина консоли
            Console.BufferHeight = 30;//высота консоли
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            int i;
            for (i = 1; i < 71; i++)
            {
                Console.Write("*");
            }
            for (i = 0; i < 28; i++)
            {
                Console.WriteLine("*");
            }
            Console.SetCursorPosition(69, 1);
            for (i = 0; i < 29; i++)
            {
                Console.SetCursorPosition(69, i);
                Console.Write("*");
            }
        }
        public void Shar()
        {
        newgame:;
            int x = 1, y = 1, offsetX = 1, offsetY = 1;
            Stena();
            
            while (true)
            {
                
                Console.CursorLeft = 1;
                Console.CursorTop = 1;
                Console.Write(shet);
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write(" ");
                x += offsetX;
                y += offsetY;
                if (x < 1)
                {
                    x = 1;
                    offsetX = -offsetX;
                }
                if (x > 68)
                {
                    x = 68;
                    offsetX = -offsetX;
                }
                if (y < 1)
                {
                    y = 1;
                    offsetY = -offsetY;
                }
                if ((y > 28) & ((x >= left) & (x <= left + str.Length)))
                {
                    y = 28;
                    offsetY = -offsetY;
                    shet = shet + 1;
                }
                if ((y > 28) & ((x < left) | (x > left + str.Length)))
                {
                    Console.CursorLeft = 15;
                    Console.CursorTop = 15;
                    Console.WriteLine(@"    Game Over
                Для продолжения игры нажмите "" Space ""
                Для выхода с игры нажмите     ""Escape""");
                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            ConsoleKey key = Console.ReadKey(false).Key;//не понял
                            switch (key)
                            {
                                case ConsoleKey.Escape:

                                    goto End;

                                case ConsoleKey.Spacebar:
                                    Console.Clear();
                                    shet = 0;
                                    goto newgame;
                            }

                        }
                    }
                }
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write("0");
                if (Console.KeyAvailable)//выход с программы
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape:
                            goto End;
                    }
                }
                for (int a = 0; a < 15; a++)
                {
                    pol();
                    
                    Thread.Sleep(1);
                }
            }
        End:;
        }
        void pol()
        {
            Console.CursorLeft = left;
            Console.CursorTop = 29;
            Console.Write(str);
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(false).Key;//не понял
                Console.CursorLeft = left;
                Console.CursorTop = 29;
                Console.Write("            ");
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (left == 1)//проверка на крайнее левое  положение
                        {
                            left = 1;

                        }
                        else
                            --left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (left == 57)//проверка на крайнее правое положение
                        {
                            left = 57;
                        }
                        else
                            ++left;
                        break;
                }
            }
        }
    
        
    }
    
class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Shar();
        }
    }

}



