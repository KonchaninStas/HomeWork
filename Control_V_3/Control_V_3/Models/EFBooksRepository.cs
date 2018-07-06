using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models
{
    public class EFBooksRepository : IBookRepository
    {
        ApplicationContext context = new ApplicationContext();
        public IEnumerable<Book> Books => context.Books.ToArray();
    }
}
