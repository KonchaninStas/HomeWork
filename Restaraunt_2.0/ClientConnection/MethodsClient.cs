using LibraryEntities.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConnection
{
   public  static class MethodsClient<T> where T : class, IEntity
    {

        public static string message = null;
        public static string MessageAddItem(string type, T item)
        {
            string temp = JsonConvert.SerializeObject(item);
            message = $"{type}!AddItem!{temp}";
            return message;
        }
        public static string MessageAddItems(string type, IEnumerable<T> items)
        {
            string temp = null;
            foreach (var x in items)
            {
                temp = $"!{JsonConvert.SerializeObject(x)}";
            }
            message = $"{type}!AddItems{temp}";
            return message;
        }
        public static string MessageChangeItem(string type,T item )
        {
            string temp = JsonConvert.SerializeObject(item);
            message = $"{type}!ChangeItem!{temp}";
            return message;
        }
        public static string MessageDelete(string type, int id)
        {
            message = $"{type}!DeleteItem!{id}";
            return message;
        }
        public static string MessageGetItem(string type, int id)
        {
            message = $"{type}!GetItem!{id}";
            return message;
        }
        public static string MessageOutpoot(string type)
        {
            message = $"{type}!Outpoot";
            return message;
        }

        public static bool AnswerAddItem(string answerMessage)
        {
            if (answerMessage == "Добавленно")
                return true;
            else
                return false;
        }
        public static bool AnswerAddItems(string answerMessage)
        {
            if (answerMessage == "Добавленно")
                return true;
            else
                return false;
        }
        public static bool AnswerDelete(string answerMessage)
        {
            if (answerMessage == "Удален")
                return true;
            else
                return false;
        }
        public static bool AnswerChangeItem(string answerMessage)
        {
            if (answerMessage == "Найден")
                return true;
            else
                return false;
        }
        public static T AnswerGetItem(string answerMessage)
        {
             return JsonConvert.DeserializeObject<T>(answerMessage);
        }
        public static IEnumerable<T> AnswerOutpot(string answerMessage)
        {
            List<T> items = new List<T>();
            string[] temp = answerMessage.Split('!');
            int i = 0;
            foreach (var x in temp)
            {
                if (x.Length > 0)
                {
                    T data = JsonConvert.DeserializeObject<T>(temp[i]);
                    items.Add(data);
                    i++;
                }
            }
            return items;
        }
    }
}
