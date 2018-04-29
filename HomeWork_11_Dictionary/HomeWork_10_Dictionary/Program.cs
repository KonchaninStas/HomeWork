using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_10_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<string, string> dictionary = new MyDictionary<string, string>();
            string path = Directory.GetCurrentDirectory() + "\\Dictionary.txt";
            if (File.Exists(path) == true)
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] str = line.Split(new Char[] { '=' });

                        dictionary.Add(str[0], str[1]);

                    }
                }
            }
            while (true)
            {
                Console.WriteLine("Введите слово");
                string original = Console.ReadLine();
                original = original.ToLower();
                original = original.Trim();
                if (original.Length > 0)
                {
                    if (dictionary.Contains(original) == true)
                    {
                        Console.WriteLine("Перевод:");
                        Console.WriteLine(dictionary[original]);
                        Console.ReadKey();
                    }
                    else
                    {
                        Add_Dict(original);
                    }
                }
                Console.Clear();
            }
            //Method for adding a new element to the dictionary
            void Add_Dict(string s)
            {
                if (dictionary.Contains(s) == false)
                {
                    Console.WriteLine($"Извините словарь не знает перевод\nВведите перевод");
                    string translate = Console.ReadLine();
                    translate = translate.ToLower();
                    translate = translate.Trim();
                    if (translate.Length > 0)
                    {
                        dictionary.Add(s, translate);
                        Console.WriteLine("Спасибо");
                        using (StreamWriter sw = new StreamWriter("Dictionary.txt", true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine($"{s}={translate}");
                        }
                    }
                }
            }
        }
    }
}




