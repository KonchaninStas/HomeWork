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

        public void SaveBook(Book book)
        {
            if(book.BookId==0)
            {
                context.Books.Add(book);
            }
            else
            {
                Book dbEntry = context.Books.FirstOrDefault(b => b.BookId == book.BookId);
                if(dbEntry!=null)
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
            Book dbEntry = context.Books.FirstOrDefault(b => b.BookId == bookID);
            if(dbEntry!=null)
            {
                context.Books.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
