using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Архивация файлов
    /// </summary>
  public static class Archiving
    {
        #region Товары
        /// <summary>
        /// Архивация товаров
        /// </summary>
        /// <param name="product">Список продуктов</param>
        /// <returns>Логическое значение</returns>
        public static bool ArchivingProduct(Product[] product)
        {
                string temp = JsonConvert.SerializeObject(product);
                return Documents.WtiteText(temp, "ProductArchiv.txt", @"..\", true);
        }
        /// <summary>
        /// Архивация товаров
        /// </summary>
        /// <param name="product">Список товаров</param>
        /// <param name="name">Название документа "ProductArchiv.txt"</param>
        /// <param name="path">Путь к файлу  @"C:\SomeDir\</param>
        /// <returns>Логическое значение</returns>
        public static bool ArchivingProduct(Product[] product, string name, string path)
        {
            string temp = JsonConvert.SerializeObject(product);
            return Documents.WtiteText(temp, name, path, true);
        }
        /// <summary>
        /// Разархивация товаров
        /// </summary>
        /// <returns>Список товаров</returns>
        public static IEnumerable<Product> DeArchivingProduct()
        {
                string str = Documents.ReadText(@"..\ProductArchiv.txt");
            return  JsonConvert.DeserializeObject<Product[]>(str);
        }
        /// <summary>
        /// Разархивация товаров
        /// </summary>
        /// <param name="path">Путь вида: @"..\ProductArchiv.txt"</param>
        /// <returns>Список товаров</returns>
        public static IEnumerable<Product> DeArchivingProduct(string path)
        {
                string str = Documents.ReadText(path);
            return  JsonConvert.DeserializeObject<Product[]>(str);
        }
        #endregion
        #region Накладные закупок
        /// <summary>
        /// Архивация накладных закупок
        /// </summary>
        /// <param name="product">Список накладных закупок</param>
        /// <returns>Логическое значение</returns>
        public static bool ArchivingInvoiceForPurchase(InvoiceForPurchase[] product)
        {
            string temp = JsonConvert.SerializeObject(product);
            return Documents.WtiteText(temp, "InvoiceForPurchaseArchiv.txt", @"..\", true);
        }
        /// <summary>
        /// Архивация  накладных закупок
        /// </summary>
        /// <param name="product">Список накладных закупок</param>
        /// <param name="name">Название документа " SalesInvoiceArchiv.txt" </param>
        /// <param name="path">Путь к файлу  @"C:\SomeDir\  или @"..\"</param >
        /// <returns>Логическое значение</returns>
        public static bool ArchivingInvoiceForPurchase(InvoiceForPurchase[] product, string name, string path)
        {
            string temp = JsonConvert.SerializeObject(product);
            return Documents.WtiteText(temp, name, path, true);
        }
        /// <summary>
        /// Разархивация накладных закупок
        /// </summary>
        /// <returns>Список накладных закупок</returns>
        public static IEnumerable<Product> DeArchivingInvoiceForPurchase()
        {
            string str = Documents.ReadText(@"..\InvoiceForPurchaseArchiv.txt");
            return JsonConvert.DeserializeObject<Product[]>(str);
        }
        /// <summary>
        /// Разархивация накладных закупок
        /// </summary>
        /// <param name="path">Путь вида: @"..\InvoiceForPurchaseArchiv.txt"</param>
        /// <returns>Список накладных закупок</returns>
        public static IEnumerable<InvoiceForPurchase> DeArchivingInvoiceForPurchase(string path)
        {
            string str = Documents.ReadText(path);
            return JsonConvert.DeserializeObject<InvoiceForPurchase[]>(str);
        }
        #endregion
        #region Накладные продаж
        /// <summary>
        /// Архивация накладных продаж
        /// </summary>
        /// <param name="product">Список накладных продаж</param>
        /// <returns>Логическое значение</returns>
        public static bool ArchivingSalesInvoice(SalesInvoice[] product)
        {
            string temp = JsonConvert.SerializeObject(product);
            return Documents.WtiteText(temp, "SalesInvoice.txt", @"..\", true);
        }
        /// <summary>
        /// Архивация  накладных продаж
        /// </summary>
        /// <param name="product">Список накладных продаж</param>
        /// <param name="name">Название документа " SalesInvoiceArchiv.txt" </param>
        /// <param name="path">Путь к файлу  @"C:\SomeDir\  или @"..\"</param >
        /// <returns>Логическое значение</returns>
        public static bool ArchivingSalesInvoice(SalesInvoice[] product, string name, string path)
        {
            string temp = JsonConvert.SerializeObject(product);
            return Documents.WtiteText(temp, name, path, true);
        }
        /// <summary>
        /// Разархивация накладных продаж
        /// </summary>
        /// <returns>Список накладных продаж</returns>
        public static IEnumerable<SalesInvoice> DeArchivingSalesInvoice()
        {
            string str = Documents.ReadText(@"..\SalesInvoiceArchiv.txt");
            return JsonConvert.DeserializeObject<SalesInvoice[]>(str);
        }
        /// <summary>
        /// Разархивация накладных продаж
        /// </summary>
        /// <param name="path">Путь вида: @"..\SalesInvoiceArchiv.txt"</param>
        /// <returns>Список накладных продаж</returns>
        public static IEnumerable<SalesInvoice> DeArchivingSalesInvoice(string path)
        {
            string str = Documents.ReadText(path);
            return JsonConvert.DeserializeObject<SalesInvoice[]>(str);
        }
        #endregion
    }
}
