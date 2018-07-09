using Control_V_3.Convert;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using DataBase;
using DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.EFRepository
{
    public class EFBooksRepository : IBookRepository
    {
        ApplicationContext context = new ApplicationContext();
        ICollection<Book> BooksList()
        {
            List<Book> Book = new List<Book>();
            foreach (var x in context.Books)
            {
                Book.Add(ConvertEntity.ConvertToBook(x));
            }
            return Book;
        }
        public IEnumerable<Book> Books => BooksList();

        public void SaveBook(Book book)
        {
            BookEnt bookEnt = ConvertEntity.ConvertToBookEnt(book);
            if (book.BookId == 0)
            {
                context.Books.Add(bookEnt);
            }
            else
            {
                BookEnt dbEntry = context.Books.FirstOrDefault(b => b.BookEntId == book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Description = book.Description;
                    dbEntry.Price = book.Price;
                    dbEntry.Category = book.Category;
                    dbEntry.Author = book.Author;
                    dbEntry.Count = book.Count;
                }
            }
            context.SaveChanges();
        }
        public Book DeleteBook(int bookID)
        {
            BookEnt dbEntry = context.Books.FirstOrDefault(b => b.BookEntId == bookID);
            if (dbEntry != null)
            {
                context.Books.Remove(dbEntry);
                context.SaveChanges();
            }
            Book book = ConvertEntity.ConvertToBook(dbEntry);
            return book;
        }
    }
}

