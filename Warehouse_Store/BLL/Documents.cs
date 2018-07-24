using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Обработка документов
    /// </summary>
   public static class Documents
    {
        /// <summary>
        /// Сохранения текста в файл
        /// </summary>
        /// <param name="Text">Текст</param>
        /// <param name="Name">Название документа "Text.txt"</param>
        /// <param name="Path">Путь к файлу  @"C:\SomeDir\</param>
        /// <param name="Write">true - дозапись в файл; false - перезапись файла</param>
        /// <returns></returns>
        public static bool WtiteText(string Text, string Name, string Path, bool Write)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter($"{Path}\"{Name}.txt", Write, System.Text.Encoding.Default))
                {
                    writer.Write(Text);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static string ReadText(string Path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Path, System.Text.Encoding.Default))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
