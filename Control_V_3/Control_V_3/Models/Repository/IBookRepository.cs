using Control_V_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        void SaveBook(Book book);
        Book DeleteBook(int bookID);
    }
}
