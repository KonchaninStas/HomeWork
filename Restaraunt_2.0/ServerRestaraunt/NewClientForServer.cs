using EntityMethods;
using LibraryEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerRestaraunt
{/// <summary>
/// New connection to the server
/// </summary>
    class NewClientForServer
    {
        public TcpClient client;
        public NewClientForServer(TcpClient Tcpclient)
        {
            client = Tcpclient;
        }
        /// <summary>
        ///  Exchange of messages with the client
        /// </summary>
        public void Loading()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] buffer = new byte[1024];
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(buffer, 0, buffer.Length);
                        builder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    string[] temp = message.Split('!');
                    string[] tmp = null;
                    if (temp[1] == null)
                    {
                        temp[1] = "0";
                    }
                    message = $"{ temp[0]}!{temp[1]}";
                    if (temp.Length > 2)
                    {
                        tmp = new string[temp.Length - 1];
                        for (int i = 2; i < temp.Length; i++)
                        {
                            tmp[i - 2] = temp[i];
                        }
                    }
                    string mes = CommandMessage(message, tmp);
                    buffer = Encoding.Unicode.GetBytes(mes);
                    stream.Write(buffer, 0, buffer.Length);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
        /// <summary>
        /// Selecting the element type
        /// </summary>
        /// <param name="message">Message for server</param>
        /// <param name="json">Items</param>
        /// <returns>Message for client</returns>
        string CommandMessage(string message, string[] json)
        {
            string outString = null;
            string[] temp = message.Split('!');
            switch (temp[0])
            {
                case "Dish":
                    outString = DishCommand(temp[1], json);
                    break;
                case "Layout":
                    outString = LayoutsCommand(temp[1], json);
                    break;
                case "Order":
                    outString = OrdersCommand(temp[1], json);
                    break;
                case "ProcurementJournal":
                    outString = ProcurementJournalsCommand(temp[1], json);
                    break;
                case "Product":
                    outString = ProductCommand(temp[1], json);
                    break;
                case "RecipeDish":
                    outString = RecipeDishCommand(temp[1], json);
                    break;
                case "UnitWeight":
                    outString = UnitWeightCommand(temp[1], json);
                    break;
                default:
                    Console.WriteLine(message);
                    outString = "Доставленно";
                    break;
            }
            return outString;
        }
        #region Message
        string DishCommand(string message, string[] json)
        {
            Dish data = null; ;
            if (json != null)
            {
                data = JsonConvert.DeserializeObject<Dish>(json[0]);
            }
            string outMessage = null;
            switch (message)
            {
                case "AddItem":
                    DishMetods.AddItem(data);
                    outMessage = "Добавленно";
                    break;
                case "AddItems":
                    List<Dish> list = new List<Dish>();
                    int i = 0;
                    foreach (var x in json)
                    {
                        Dish u = JsonConvert.DeserializeObject<Dish>(json[i]);
                        list.Add(u);
                    }
                    DishMetods.AddItems(list);
                    outMessage = "Добавленно";
                    break;
                case "ChangeItem":
                    if (DishMetods.ChangeItem(data) == true)
                    {
                        outMessage = "Найден";
                    }
                    else outMessage = "Не найден";
                    break;
                case "DeleteItem":
                    DishMetods.DeleteItem(Convert.ToInt32(json[0]));
                    outMessage = "Удален";
                    break;
                case "GetItem":
                    string s = JsonConvert.SerializeObject(DishMetods.GetItem(Convert.ToInt32(json[0])));
                    outMessage = s;
                    break;
                case "Outpoot":
                    string outs = null;
                    List<Dish> unitWeights = DishMetods.Outpoot().ToList();
                    foreach (var x in unitWeights)
                    {
                        outs = $"{JsonConvert.SerializeObject(x)}!";
                    }

                    outMessage = outs;
                    break;
                default:
                    outMessage = "Dish connect";
                    break;
            }
            return outMessage;
        }
        string LayoutsCommand(string message, string[] json)
        {
            Layouts data = null; ;
            if (json != null)
            {
                data = JsonConvert.DeserializeObject<Layouts>(json[0]);
            }
            string outMessage = null;
            switch (message)
            {
                case "AddItem":
                    LayoutsMethods.AddItem(data);
                    outMessage = "Добавленно";
                    break;
                case "AddItems":
                    List<Layouts> list = new List<Layouts>();
                    int i = 0;
                    foreach (var x in json)
                    {
                        Layouts u = JsonConvert.DeserializeObject<Layouts>(json[i]);
                        list.Add(u);
                    }
                    LayoutsMethods.AddItems(list);
                    outMessage = "Добавленно";
                    break;
                case "ChangeItem":
                    if (LayoutsMethods.ChangeItem(data) == true)
                    {
                        outMessage = "Найден";
                    }
                    else outMessage = "Не найден";
                    break;
                case "DeleteItem":
                    LayoutsMethods.DeleteItem(Convert.ToInt32(json[0]));
                    outMessage = "Удален";
                    break;
                case "GetItem":
                    string s = JsonConvert.SerializeObject(LayoutsMethods.GetItem(Convert.ToInt32(json[0])));
                    outMessage = s;
                    break;
                case "Outpoot":
                    string outs = null;
                    List<Layouts> unitWeights = LayoutsMethods.Outpoot().ToList();
                    foreach (var x in unitWeights)
                    {
                        outs = $"{outs}!{JsonConvert.SerializeObject(x)}";
                    }
                    outMessage = outs;
                    break;
                default:
                    outMessage = "Layouts connect";
                    break;
            }
            return outMessage;
        }
        string OrdersCommand(string message, string[] json)
        {
            Orders data = null; ;
            if (json != null)
            {
                data = JsonConvert.DeserializeObject<Orders>(json[0]);
            }
            string outMessage = null;
            switch (message)
            {
                case "AddItem":
                    OrdersMethods.AddItem(data);
                    outMessage = "Добавленно";
                    break;
                case "AddItems":
                    List<Orders> list = new List<Orders>();
                    int i = 0;
                    foreach (var x in json)
                    {
                        Orders u = JsonConvert.DeserializeObject<Orders>(json[i]);
                        list.Add(u);
                    }
                    OrdersMethods.AddItems(list);
                    outMessage = "Добавленно";
                    break;
                case "ChangeItem":
                    if (OrdersMethods.ChangeItem(data) == true)
                    {
                        outMessage = "Найден";
                    }
                    else outMessage = "Не найден";
                    break;
                case "DeleteItem":
                    OrdersMethods.DeleteItem(Convert.ToInt32(json[0]));
                    outMessage = "Удален";
                    break;
                case "GetItem":
                    string s = JsonConvert.SerializeObject(OrdersMethods.GetItem(Convert.ToInt32(json[0])));
                    outMessage = s;
                    break;
                case "Outpoot":
                    string outs = null;
                    List<Orders> unitWeights = OrdersMethods.Outpoot().ToList();
                    foreach (var x in unitWeights)
                    {
                        outs = $"{outs}!{JsonConvert.SerializeObject(x)}";
                    }
                    outMessage = outs;
                    break;
                default:
                    outMessage = "Orders connect";
                    break;
            }
            return outMessage;
        }
        string ProcurementJournalsCommand(string message, string[] json)
        {
            ProcurementJournals data = null; ;
            if (json != null)
            {
                data = JsonConvert.DeserializeObject<ProcurementJournals>(json[0]);
            }
            string outMessage = null;
            switch (message)
            {
                case "AddItem":
                    ProcurementJournalsMethods.AddItem(data);
                    outMessage = "Добавленно";
                    break;
                case "AddItems":
                    List<ProcurementJournals> list = new List<ProcurementJournals>();
                    int i = 0;
                    foreach (var x in json)
                    {
                        ProcurementJournals u = JsonConvert.DeserializeObject<ProcurementJournals>(json[i]);
                        list.Add(u);
                    }
                    ProcurementJournalsMethods.AddItems(list);
                    outMessage = "Добавленно";
                    break;
                case "ChangeItem":
                    if (ProcurementJournalsMethods.ChangeItem(data) == true)
                    {
                        outMessage = "Найден";
                    }
                    else outMessage = "Не найден";
                    break;
                case "DeleteItem":
                    ProcurementJournalsMethods.DeleteItem(Convert.ToInt32(json[0]));
                    outMessage = "Удален";
                    break;
                case "GetItem":
                    string s = JsonConvert.SerializeObject(ProcurementJournalsMethods.GetItem(Convert.ToInt32(json[0])));
                    outMessage = s;
                    break;
                case "Outpoot":
                    string outs = null;
                    List<ProcurementJournals> unitWeights = ProcurementJournalsMethods.Outpoot().ToList();
                    foreach (var x in unitWeights)
                    {
                        outs = $"{outs}!{JsonConvert.SerializeObject(x)}";
                    }
                    outMessage = outs;
                    break;
                default:
                    outMessage = "ProcurementJournals connect";
                    break;
            }
            return outMessage;
        }
        string ProductCommand(string message, string[] json)
        {
            Product data = null; ;
            if (json != null)
            {
                data = JsonConvert.DeserializeObject<Product>(json[0]);
            }
            string outMessage = null;
            switch (message)
            {
                case "AddItem":
                    ProductMethods.AddItem(data);
                    outMessage = "Добавленно";
                    break;
                case "AddItems":
                    List<Product> list = new List<Product>();
                    int i = 0;
                    foreach (var x in json)
                    {
                        Product u = JsonConvert.DeserializeObject<Product>(json[i]);
                        list.Add(u);
                    }
                    ProductMethods.AddItems(list);
                    outMessage = "Добавленно";
                    break;
                case "ChangeItem":
                    if (ProductMethods.ChangeItem(data) == true)
                    {
                        outMessage = "Найден";
                    }
                    else outMessage = "Не найден";
                    break;
                case "DeleteItem":
                    ProductMethods.DeleteItem(Convert.ToInt32(json[0]));
                    outMessage = "Удален";
                    break;
                case "GetItem":
                    string s = JsonConvert.SerializeObject(ProductMethods.GetItem(Convert.ToInt32(json[0])));
                    outMessage = s;
                    break;
                case "Outpoot":
                    string outs = null;
                    List<Product> unitWeights = ProductMethods.Outpoot().ToList();
                    foreach (var x in unitWeights)
                    {
                        outs = $"{outs}!{JsonConvert.SerializeObject(x)}";
                    }
                    outMessage = outs;
                    break;
                default:
                    outMessage = "Product connect";
                    break;
            }
            return outMessage;
        }
        string RecipeDishCommand(string message, string[] json)
        {
            RecipeDish data = null;
            if (json != null)
            {
                data = JsonConvert.DeserializeObject<RecipeDish>(json[0]);
            }
            string outMessage = null;
            switch (message)
            {
                case "AddItem":
                    RecipeDishMethods.AddItem(data);
                    outMessage = "Добавленно";
                    break;
                case "AddItems":
                    List<RecipeDish> list = new List<RecipeDish>();
                    int i = 0;
                    foreach (var x in json)
                    {
                        RecipeDish u = JsonConvert.DeserializeObject<RecipeDish>(json[i]);
                        list.Add(u);
                    }
                    RecipeDishMethods.AddItems(list);
                    outMessage = "Добавленно";
                    break;
                case "ChangeItem":
                    if (RecipeDishMethods.ChangeItem(data) == true)
                    {
                        outMessage = "Найден";
                    }
                    else outMessage = "Не найден";
                    break;
                case "DeleteItem":
                    RecipeDishMethods.DeleteItem(Convert.ToInt32(json[0]));
                    outMessage = "Удален";
                    break;
                case "GetItem":
                    string s = JsonConvert.SerializeObject(RecipeDishMethods.GetItem(Convert.ToInt32(json[0])));
                    outMessage = s;
                    break;
                case "Outpoot":
                    string outs = null;
                    List<RecipeDish> unitWeights = RecipeDishMethods.Outpoot().ToList();
                    foreach (var x in unitWeights)
                    {
                        outs = $"{outs}!{JsonConvert.SerializeObject(x)}";
                    }
                    outMessage = outs;
                    break;
                default:
                    outMessage = "RecipeDish connect";
                    break;
            }
            return outMessage;
        }
        string UnitWeightCommand(string message, string[] json)
        {
            UnitWeight data = null;
            if (json != null)
            {
                data = JsonConvert.DeserializeObject<UnitWeight>(json[0]);
            }
            string outMessage = null;
            switch (message)
            {
                case "AddItem":
                    UnitWeightMethods.AddItem(data);
                    outMessage = "Добавленно";
                    break;
                case "AddItems":
                    List<UnitWeight> list = new List<UnitWeight>();
                    int i = 0;
                    foreach (var x in json)
                    {
                        UnitWeight u = JsonConvert.DeserializeObject<UnitWeight>(json[i]);
                        list.Add(u);
                    }
                    UnitWeightMethods.AddItems(list);
                    outMessage = "Добавленно";
                    break;
                case "ChangeItem":
                    if (UnitWeightMethods.ChangeItem(data) == true)
                    {
                        outMessage = "Найден";
                    }
                    else outMessage = "Не найден";
                    break;
                case "DeleteItem":
                    UnitWeightMethods.DeleteItem(Convert.ToInt32(json[0]));
                    outMessage = "Удален";
                    break;
                case "GetItem":
                    string s = JsonConvert.SerializeObject(UnitWeightMethods.GetItem(Convert.ToInt32(json[0])));
                    outMessage = s;
                    break;
                case "Outpoot":
                    string outs = null;
                    List<UnitWeight> unitWeights = UnitWeightMethods.Outpoot().ToList();
                    foreach (var x in unitWeights)
                    {
                        outs = $"{outs}!{JsonConvert.SerializeObject(x)}";
                    }
                    outMessage = outs;
                    break;
                default:
                    outMessage = "UnitWeight connect";
                    break;
            }
            return outMessage;
        }
        #endregion
    }
}
