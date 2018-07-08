using Control_V_3.Controllers;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class AdminControllerTests
    {/// <summary>
     /// All element test
        /// </summary>
        [Fact]
        public void Index_Contains_All_Books()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(new Book[]
            {
                new Book {BookId=1, Name="B1"},
                new Book {BookId=2, Name="B2"},
                new Book {BookId=3, Name="B3"}
            });
            AdminController target = new AdminController(mock.Object);
            //Act
            Book[] result = GetViewModel<IEnumerable<Book>>(target.Index())?.ToArray();
            //Cheking conditions
            Assert.Equal(3, result.Length);
            Assert.Equal("B1", result[0].Name);
            Assert.Equal("B2", result[1].Name);
            Assert.Equal("B3", result[2].Name);
        }
        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
        /// <summary>
        /// Modifying an item
        /// </summary>
        [Fact]
        public void Can_Edit_Book()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(new Book[]
            {
                new Book {BookId=1, Name="B1"},
                new Book {BookId=2, Name="B2"},
                new Book {BookId=3, Name="B3"}
            });
            AdminController target = new AdminController(mock.Object);
            //Act
            Book b1 = GetViewModel<Book>(target.Edit(1));
            Book b2 = GetViewModel<Book>(target.Edit(2));
            Book b3 = GetViewModel<Book>(target.Edit(3));
            //Cheking conditions
            Assert.Equal(1, b1.BookId);
            Assert.Equal(2, b2.BookId);
            Assert.Equal(3, b3.BookId);
        }
        /// <summary>
        /// Cannot edit nonexistent book
        /// </summary>
        [Fact]
        public void Cannot_Edit_Nonexistent_Book()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(new Book[]
            {
                new Book {BookId=1, Name="B1"},
                new Book {BookId=2, Name="B2"},
                new Book {BookId=3, Name="B3"}
            });
            AdminController target = new AdminController(mock.Object);
            //Act
            Book result = GetViewModel<Book>(target.Edit(4));
            //Cheking conditions
            Assert.Null(result);
        }
        /// <summary>
        /// Can save valid changes
        /// </summary>
        [Fact]
        public void Can_Save_Valid_Changes()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            AdminController target = new AdminController(mock.Object)
            {
                TempData = tempData.Object
            };
            Book book = new Book { Name = "Test" };
            //Act
            IActionResult result = target.Edit(book);
            //Cheking conditions
            mock.Verify(m => m.SaveBook(book));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
        }
        /// <summary>
        /// Cannot save invalid changes
        /// </summary>
        [Fact]
        public void Cannot_Save_Invalid_Changes()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            AdminController target = new AdminController(mock.Object);
            Book book = new Book { Name = "Test" };
            target.ModelState.AddModelError("error", "error");
            //Act
            IActionResult result = target.Edit(book);
            //Cheking conditions
            mock.Verify(m => m.SaveBook(It.IsAny<Book>()), Times.Never());
            Assert.IsType<ViewResult>(result);
        }
        /// <summary>
        /// Can delete valid books
        /// </summary>
        [Fact]
        public void Can_Delete_Valid_Books()
        {
            //Model
            Book book = new Book { BookId = 2, Name = "Test" };
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[]
            {
                new Book{ BookId=1, Name="B1"}, book,
                new Book{BookId=3, Name="B3"}
            });
            AdminController target = new AdminController(mock.Object);
            //Act
            target.Delete(book.BookId);
            //Cheking conditions
            mock.Verify(m => m.DeleteBook(book.BookId));
        }
    }
}
