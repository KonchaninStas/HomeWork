using Control_V_3.Components;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //Model
            Category cat1 = new Category { Name = "Cat1" };
            Category cat2 = new Category { Name = "Cat2" };
            Category cat3 = new Category { Name = "Cat3" };
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[]
            {
                new Book{BookId=1, Name= "B1", Category="Cat1"},
                new Book{BookId=2, Name="B2", Category="Cat1"},
                new Book{BookId=3, Name="B3", Category="Cat2"},
                new Book{BookId=4, Name="B4", Category="Cat3"},
            });
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            //Act
            string[] result = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();
            //Cheking conditions
            Assert.True(Enumerable.SequenceEqual(new string[] { "Cat1", "Cat2", "Cat3" }, result));
        }
        [Fact]
        public void Indicates_Selected_Category()
        {
            //Model
            string categorySelect = "Dish";
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(new Book[]
                {
                new Book{BookId=1, Name= "B1", Category="Dish"},
                new Book{BookId=2, Name="B2", Category="Car"},
                });
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };
            //Act
            target.RouteData.Values["category"] = categorySelect;
            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];
            //Cheking conditions
            Assert.Equal(categorySelect, result);

        }
    }
}
