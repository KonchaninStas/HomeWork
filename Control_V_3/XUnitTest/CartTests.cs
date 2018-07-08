using Control_V_3.Models;
using Control_V_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            //Model
            Book b1 = new Book { BookId = 1, Name = "B1" };
            Book b2 = new Book { BookId = 2, Name = "B2" };
            Cart targer = new Cart();
            //Act
            targer.AddItem(b1, 1);
            targer.AddItem(b2, 1);
            CartLine[] result = targer.Lines.ToArray();
            //Cheking conditions
            Assert.Equal(2, result.Length);
            Assert.Equal(b1, result[0].Book);
            Assert.Equal(b2, result[1].Book);
        }
        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //Model
            Book b1 = new Book { BookId = 1, Name = "B1" };
            Book b2 = new Book { BookId = 2, Name = "B2" };
            Cart targer = new Cart();
            //Act
            targer.AddItem(b1, 1);
            targer.AddItem(b2, 1);
            targer.AddItem(b1, 10);
            CartLine[] result = targer.Lines.OrderBy(b => b.Book.BookId).ToArray();
            //Cheking conditions
            Assert.Equal(2, result.Length);
            Assert.Equal(11, result[0].Quantity);
            Assert.Equal(1, result[1].Quantity);
        }
        [Fact]
        public void Remove_Line()
        {
            //Model
            Book b1 = new Book { BookId = 1, Name = "B1" };
            Book b2 = new Book { BookId = 2, Name = "B2" };
            Book b3 = new Book { BookId = 3, Name = "B3" };
            Cart targer = new Cart();
            targer.AddItem(b1, 1);
            targer.AddItem(b2, 3);
            targer.AddItem(b3, 5);
            targer.AddItem(b2, 1);
            //Act
            targer.RemoveLine(b2);
            //Cheking conditions
            Assert.Empty(targer.Lines.Where(b => b.Book == b2));
            Assert.Equal(2, targer.Lines.Count());
        }
        [Fact]
        public void Calculate_Cart_Total()
        {
            //Model
            Book b1 = new Book { BookId = 1, Name = "B1", Price=100M };
            Book b2 = new Book { BookId = 2, Name = "B2", Price=50M };
            Cart targer = new Cart();
            //Act
            targer.AddItem(b1, 1);
            targer.AddItem(b2, 1);
            targer.AddItem(b1, 3);
            decimal result = targer.ComputeTotalValue();
            //Cheking conditions
            Assert.Equal(450M, result);
        }
        [Fact]
        public void Can_Clear_Contents()
        {
            //Model
            Book b1 = new Book { BookId = 1, Name = "B1", Price = 100M };
            Book b2 = new Book { BookId = 2, Name = "B2", Price = 50M };
            Cart targer = new Cart();
            targer.AddItem(b1, 1);
            targer.AddItem(b2, 1);
            //Act
            targer.Clear();
            //Cheking conditions
            Assert.Empty(targer.Lines);
        }

    }
}
