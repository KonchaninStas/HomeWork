using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// Статистика
    /// </summary>
   public class StatisticsEnt : EntityEnt
    {
        /// <summary>
        /// Количество товара в наличие
        /// </summary>
        public int QuantityOfGoodsInStock { get; set; }
        /// <summary>
        /// Количество проданного товара
        /// </summary>
        public int NumberOfGoodsSold { get; set; }
        /// <summary>
        /// Средняя себестоимость товара
        /// </summary>
        public decimal AverageCostOfGoods { get; set; }
        /// <summary>
        /// Средняя стоимость продажи
        /// </summary>
        public decimal AverageSellingPrice { get; set; }
        /// <summary>
        /// Дата составления документа
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
