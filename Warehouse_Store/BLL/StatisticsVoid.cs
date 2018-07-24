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
    /// Статистика
    /// </summary>
  public static class StatisticsVoid
    {
        /// <summary>
        /// Статистика по товару
        /// </summary>
        /// <returns>Логическое значение</returns>
        public static bool StatisticsProduct ()
        {
            decimal AverageCostOfGoods = 0;
            decimal AverageSellingPrice = 0;
           var ProductsInStock = ProductBll.ProductsInStock();
           var ProductsInSales = ProductBll.ProductsInSales();
            foreach (var item in ProductsInStock)
            {
                AverageCostOfGoods += item.CostPrice;
            }
            foreach (var item in ProductsInSales)
            {
                AverageCostOfGoods += item.CostPrice;
                AverageSellingPrice += item.Price;
            }
            Statistics statistics = new Statistics
            {
                NumberOfGoodsSold = ProductsInSales.Count(),
                QuantityOfGoodsInStock = ProductsInStock.Count(),
                AverageCostOfGoods=AverageCostOfGoods,
                AverageSellingPrice=AverageSellingPrice,
                Date=DateTime.Now
            };
           return StatisticsMethod.AddItem(statistics);
        }
    }
}
