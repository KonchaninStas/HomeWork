using ConnectionToDateBase;
using Convert;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities;

namespace EntityMethods
{
    /// <summary>
    /// Методы для работы клиентами
    /// </summary>
    public static class ClientUserMethods
    {
        /// <summary>
        /// Добавить новый элемент
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItem(ClientUser item)
        {
            return Unit.ClientUserRepository.AddItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Добавить массив элементов
        /// </summary>
        /// <param name="items">массив элементов</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItems(IEnumerable<ClientUser> items)
        {
            List<ClientUserEnt> clients = new List<ClientUserEnt>();
            foreach (var item in items)
            {
                clients.Add(ConvertEntity.Convert(item));
            }
            return Unit.ClientUserRepository.AddItems(clients);
        }
        /// <summary>
        /// Поиск элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool ChangeItem(ClientUser item)
        {
            return Unit.ClientUserRepository.ChangeItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Логическое значение</returns>
        static public bool DeleteItem(int id)
        {
            return Unit.ClientUserRepository.DeleteItem(id);
        }
        /// <summary>
        /// Получение элемента по индексу
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Элемент</returns>
        static public ClientUser GetItem(int id)
        {
            return ConvertEntity.Convert(Unit.ClientUserRepository.GetItem(id));
        }
        /// <summary>
        /// Лист всех элементов
        /// </summary>
        /// <returns>Лист всех элементов</returns>
        static public IEnumerable<ClientUser> Outpoot()
        {
            List<ClientUserEnt> list = Unit.ClientUserRepository.AllItems.ToList();
            List<ClientUser> clients = new List<ClientUser>();
            foreach (var item in list)
            {
                clients.Add(ConvertEntity.Convert(item));
            }
            return clients;
        }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns>Логическое значение</returns>
        static public bool SaveChanges()
        {
            return Unit.ClientUserRepository.SaveChanges();
        }
    }
}
