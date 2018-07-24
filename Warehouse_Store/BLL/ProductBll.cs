using Entities;
using EntityMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Работа с товарами
    /// </summary>
  public static class ProductBll
    {
        #region Выборка и сортировка
        /// <summary>
        /// выбирает проданые товары
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Product> ProductsInSales()
        {
            var x = from m in ProductMethods.Outpoot()
                    where m.Status = false
                    select m;
            return x;
        }
        /// <summary>
        /// выбирает непроданые товары
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Product> ProductsInStock()
        {
            var x = from m in ProductMethods.Outpoot()
                    where m.Status = true
                    select m;
            return x;
        }
        /// <summary>
        /// Сортирует товары по имени и по цене по возрастанию
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static IEnumerable<Product> SortByName(IEnumerable<Product> products)
        {
            var x = from n in products
                    orderby n.Name
                    orderby n.Price
                    select n;
            return x;
        }
        /// <summary>
        /// возвращает товар и количество на складе
        /// </summary>
        /// <param name="products">масив товаров</param>
        /// <returns></returns>
        public static Dictionary<Product, int> ProductsSortByNameAndPrice(IEnumerable<Product> products)
        {
            products = SortByName(products);
            Dictionary<Product, int> prod = new Dictionary<Product, int>();
            foreach (var item in products)
            {
                if (prod.Count == 0)
                {
                    prod.Add(item, 0);
                }
                else if (item.Name == prod.Last().Key.Name && item.Price == prod.Last().Value)
                {
                    var x = prod.Last().Value;
                    x++;
                    prod.Remove(prod.Last().Key);
                    prod.Add(item, x);
                }
                else
                {
                    prod.Add(item, 0);
                }
            }
            return prod;
        }
        #endregion
        #region Продажи
        /// <summary>
        /// Поиск и продажа товара
        /// </summary>
        /// <param name="product">Товар</param>
        /// <returns>Логическое значение</returns>
        public static bool Sales(Product product)
        {
            var x = ProductMethods.GetItem(product.Id);
            if (x != null)
            {
                x.Status = false;
                x.DateOfSale = DateTime.Now;
                return ProductMethods.SaveChanges();
            }
            else return false;
        }
        /// <summary>
        /// Поиск и продажа товара
        /// </summary>
        /// <param name="productId">ID товара</param>
        /// <returns>Логическое значение</returns>
        public static bool Sales(int productId)
        {
            var x = ProductMethods.GetItem(productId);
            if (x != null)
            {
                x.Status = false;
                x.DateOfSale = DateTime.Now;
                return ProductMethods.SaveChanges();
            }
            else return false;
        }
        /// <summary>
        /// Поиск и продажа товара
        /// </summary>
        /// <param name="productName">Название товара</param>
        /// <param name="Price">Цена товара</param>
        /// <returns>Логическое значение</returns>
        public static bool Sales(string productName, decimal Price)
        {
            var x = from m in ProductMethods.Outpoot()
                    where productName == m.Name
                    where Price == m.Price
                    orderby m.DateOfPurchase
                    select m;
            if (x != null)
            {
                var f = x.First();
                f.Status = false;
                f.DateOfSale = DateTime.Now;
                return ProductMethods.SaveChanges();
            }
            else return false;
        }
        #endregion
        #region Поиск
        /// <summary>
        /// Поиск по имени товара
        /// </summary>
        /// <param name="name">Имя товара</param>
        /// <returns>Список товаров</returns>
        public static Dictionary<Product, int> SearchByName(string name)
        {
            var x = ProductsSortByNameAndPrice(ProductMethods.Outpoot());
            Dictionary<Product, int> prod = new Dictionary<Product, int>();
              var p  = from m in x
                    where m.Key.Name == name
                    select m;
            foreach (var item in p)
            {
                prod.Add(item.Key, item.Value);
            }
            return prod;
        }
        /// <summary>
        /// Поиск по описанию
        /// </summary>
        /// <param name="name">Имя товара</param>
        /// <returns>Список товаров</returns>
        public static Dictionary<Product, int> SearchByDescription(string name)
        {
            var x = ProductsSortByNameAndPrice(ProductMethods.Outpoot());
            Dictionary<Product, int> prod = new Dictionary<Product, int>();
            var p = from m in x
                    where m.Key.Description.Contains(name)
                    select m;
            foreach (var item in p)
            {
                prod.Add(item.Key, item.Value);
            }
            return prod;
        }
        /// <summary>
        /// Поиск по названию компании
        /// </summary>
        /// <param name="companyName">Название компании</param>
        /// <returns>Список товаров</returns>
        public static Dictionary<Product, int> SearchByCompany(string companyName)
        {
            var x = ProductsSortByNameAndPrice(ProductMethods.Outpoot());
            Dictionary<Product, int> prod = new Dictionary<Product, int>();
            var p = from m in x
                    where m.Key.InvoiceForPurchase.CompanyProvider.Name == companyName
                    select m;
            foreach (var item in p)
            {
                prod.Add(item.Key, item.Value);
            }
            return prod;
        }
        /// <summary>
        /// Поиск по цене(товары с меньшей ценой)
        /// </summary>
        /// <param name="price">Цена меньше которой будет поиск</param>
        /// <returns>Список товаров</returns>
        public static Dictionary<Product, int> Search(decimal price)
        {
            var x = ProductsSortByNameAndPrice(ProductMethods.Outpoot());
            Dictionary<Product, int> prod = new Dictionary<Product, int>();
            var p = from m in x
                    where m.Key.Price >= price
                    select m;
            foreach (var item in p)
            {
                prod.Add(item.Key, item.Value);
            }
            return prod;
        }
        #endregion
        #region Инвентаризация
        /// <summary>
        /// Инвентаризация продуктов
        /// </summary>
        /// <returns>Логическое значение</returns>
        public static bool InventarizationProduct()
        {
            var x = ProductsInSales().ToArray();
            if (StatisticsVoid.StatisticsProduct() == true)
            {
                if (Archiving.ArchivingProduct(x) == true)
                    foreach (var item in x)
                    {
                        ProductMethods.DeleteItem(item.Id);
                    }
                return true;
            }
            else return false;
        }
        #endregion
    }
}
