using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Формирования шаблонов документов
    /// </summary>
    public static class CreateDocumentTemplates
    {
        /// <summary>
        /// Формирование информации про товар для клиента
        /// </summary>
        /// <param name="product">Товар</param>
        /// <returns>Текст</returns>
        public static string ProductTemplatesForClient(Product product)
        {
            return $"\tНайменование:{product.Name}\n\tОписание:\n\t\t{product.Description}\n" +
                $"\tЦена: {product.Price} грн";
        }
        /// <summary>
        /// Формирование информации про товар для сотрудника
        /// </summary>
        /// <param name="product">Товар</param>
        /// <returns>Текст</returns>
        public static string ProductTemplatesForEmploee(Product product)
        {
            return $"\tНомер товара:{product.Id}\tНайменование:{product.Name}\n\tОписание:\n\t\t{product.Description}\n" +
               $"\tЦена: {product.Price} грн\n\tПоставщик:{product.InvoiceForPurchase.CompanyProvider.Name}";
        }
    }
}
