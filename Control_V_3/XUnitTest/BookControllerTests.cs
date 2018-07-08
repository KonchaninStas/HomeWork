using Control_V_3.Controllers;
using Control_V_3.Models;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Control_V_3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTest
{
    public class BookControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m =>m.Books).Returns(new Book[]
            {
                new Book { BookId=1,  Author="1", Name="BMW1", Price=50},
                new Book { BookId=2, Author="2", Name="BMW2", Price=60},
                new Book { BookId=3,  Author="3", Name="BMW3", Price=70},
                new Book { BookId=4,  Author="4", Name="BMW4", Price=80},
                new Book { BookId=5, Author="5", Name="BMW5", Price=590},
            });
            BookController bookController = new BookController(mock.Object);
            bookController.PageSize = 3;
            //Act
            BooksListViewModel result = bookController.List(null,2).ViewData.Model as BooksListViewModel;
            Book[] books = result.Books.ToArray();
            //Cheking conditions
            Assert.True(books.Length == 2);
            Assert.Equal("BMW4", books[0].Name);
            Assert.Equal("BMW5", books[1].Name);
        }
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(new Book[]
                {
                    new Book {BookId=1,Name="B1"},
                    new Book {BookId=2,Name="B2"},
                    new Book {BookId=3,Name="B3"},
                    new Book {BookId=4,Name="B4"},
                    new Book {BookId=5,Name="B5"},
                });
            BookController bookController = new BookController(mock.Object)
            {
                PageSize = 3
            };
            //Act
            BooksListViewModel result = bookController.List(null, 2).ViewData.Model as BooksListViewModel;
            PadingInfo pageInfo = result.PadingInfo;
            //Cheking conditions
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
        [Fact]
        public void Can_Filter_Books ()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[]
            {
                new Book{BookId=1, Name= "B1", Category="Cat1"},
                new Book{BookId=2, Name="B2", Category="Cat2"},
                new Book{BookId=3, Name="B3", Category="Cat1"},
                new Book{BookId=4, Name="B4", Category="Cat2"},
                new Book{BookId=5, Name="B5", Category="Cat3"},
            });
            BookController controller = new BookController(mock.Object);
            controller.PageSize = 3;
            //Act
            Book[] result = (controller.List("Cat2", 1).ViewData.Model as BooksListViewModel).Books.ToArray();
            //Cheking conditions
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "B2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "B4" && result[1].Category == "Cat2");
        }
        [Fact]
        public void Generate_Category_Specific_Book_Count()
        {
            //Model
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(new Book[]
                {
                new Book{BookId=1, Name= "B1", Category="Cat1"},
                new Book{BookId=2, Name="B2", Category="Cat2"},
                new Book{BookId=3, Name="B3", Category="Cat1"},
                new Book{BookId=4, Name="B4", Category="Cat2"},
                new Book{BookId=5, Name="B5", Category="Cat3"},
        });
            BookController target = new BookController(mock.Object);
            target.PageSize = 3;
            Func<ViewResult, BooksListViewModel> GetModel = result =>
              result?.ViewData?.Model as BooksListViewModel;
            //Act
            int? res1 = GetModel(target.List("Cat1"))?.PadingInfo.TotalItems;
            int? res2 = GetModel(target.List("Cat2"))?.PadingInfo.TotalItems;
            int? res3 = GetModel(target.List("Cat3"))?.PadingInfo.TotalItems;
            int? resAll = GetModel(target.List(null))?.PadingInfo.TotalItems;
            //Cheking conditions
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);
        }
    }
}
