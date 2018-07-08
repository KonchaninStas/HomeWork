using Control_V_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem (Book book, int quantity)
        {
            CartLine line = lineCollection.Where(b => b.Book.BookId == book.BookId).FirstOrDefault();
            if(line==null)
            {
                lineCollection.Add(new CartLine
                {
                    Book=book,
                    Quantity=quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Book book) =>
            lineCollection.RemoveAll(l => l.Book.BookId == book.BookId);
        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(b => b.Book.Price * b.Quantity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
}
