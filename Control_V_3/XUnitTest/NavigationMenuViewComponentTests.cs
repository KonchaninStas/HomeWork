using Control_V_3.Components;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Mvc.ViewComponents;
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
            Category cat1 = new Category { Name = "Cat1" };
            Category cat2 = new Category { Name = "Cat2" };
            Category cat3 = new Category { Name = "Cat3" };
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[]
            {
                new Book{BookId=1, Name= "B1", Category=cat1},
                new Book{BookId=2, Name="B2", Category=cat1},
                new Book{BookId=3, Name="B3", Category=cat2},
                new Book{BookId=4, Name="B4", Category=cat3},
            });
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            string[] result = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();
            Assert.True(Enumerable.SequenceEqual(new string[] { cat1.Name, cat2.Name, cat3.Name }, result));
        }
    }
}
