using LibraryEntities.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConnection
{/// <summary>
 /// Сlass that creates the text of the request and receives the text of the response
 /// </summary>
 /// <typeparam name="T">Class entity</typeparam>
    public static class MethodsClient<T> where T : class, IEntity
    {
        public static string message = null;
        #region Message methods
        /// <summary>
        /// Request to create a new item
        /// </summary>
        /// <param name="type">Type of element</param>
        /// <param name="item">Element</param>
        /// <returns>Query string</returns>
        public static string MessageAddItem(string type, T item)
        {
            string temp = JsonConvert.SerializeObject(item);
            message = $"{type}!AddItem!{temp}";
            return message;
        }
        /// <summary>
        /// Request to create a new items
        /// </summary>
        /// <param name="type">Type of element</param>
        /// <param name="items">Elements</param>
        /// <returns>Query string</returns>
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
        /// <summary>
        /// Checks if there is an element in the database
        /// </summary>
        /// <param name="type">Type of element</param>
        /// <param name="item">Element</param>
        /// <returns>Query string</returns>
        public static string MessageChangeItem(string type,T item )
        {
            string temp = JsonConvert.SerializeObject(item);
            message = $"{type}!ChangeItem!{temp}";
            return message;
        }
        /// <summary>
        /// Removes an item from the database
        /// </summary>
        /// <param name="type">Type of element</param>
        /// <param name="id">Element</param>
        /// <returns>Query string</returns>
        public static string MessageDelete(string type, int id)
        {
            message = $"{type}!DeleteItem!{id}";
            return message;
        }
        /// <summary>
        /// Get the item from the database by id
        /// </summary>
        /// <param name="type">Type of element</param>
        /// <param name="id">id element</param>
        /// <returns>Query string</returns>
        public static string MessageGetItem(string type, int id)
        {
            message = $"{type}!GetItem!{id}";
            return message;
        }
        /// <summary>
        /// Request for all items
        /// </summary>
        /// <param name="type">Type of element</param>
        /// <returns>Query string</returns>
        public static string MessageOutpoot(string type)
        {
            message = $"{type}!Outpoot";
            return message;
        }
        #endregion
        #region Answer methods
        /// <summary>
        /// Returns whether the query is executed or not on element additions
        /// </summary>
        /// <param name="answerMessage">Server Response</param>
        /// <returns>Boolean response</returns>
        public static bool AnswerAddItem(string answerMessage)
        {
            if (answerMessage == "Добавленно")
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns whether the query is executed or not on additions
        /// </summary>
        /// <param name="answerMessage">Server Response</param>
        /// <returns>Boolean response</returns>
        public static bool AnswerAddItems(string answerMessage)
        {
            if (answerMessage == "Добавленно")
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns whether the request is executed or not to delete the item
        /// </summary>
        /// <param name="answerMessage">Server Response</param>
        /// <returns>Boolean response</returns>
        public static bool AnswerDelete(string answerMessage)
        {
            if (answerMessage == "Удален")
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns whether an item is found
        /// </summary>
        /// <param name="answerMessage">Server Response</param>
        /// <returns>Boolean response</returns>
        public static bool AnswerChangeItem(string answerMessage)
        {
            if (answerMessage == "Найден")
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns an item
        /// </summary>
        /// <param name="answerMessage">Server Response</param>
        /// <returns>Element</returns>
        public static T AnswerGetItem(string answerMessage)
        {
             return JsonConvert.DeserializeObject<T>(answerMessage);
        }
        /// <summary>
        ///  Will return the collection of elements
        /// </summary>
        /// <param name="answerMessage">Server Response</param>
        /// <returns>collection of elements</returns>
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
        #endregion
    }
}
