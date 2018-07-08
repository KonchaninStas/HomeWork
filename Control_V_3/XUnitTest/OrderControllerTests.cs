using Control_V_3.Controllers;
using Control_V_3.Models;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class OrderControllerTests
    {
        [Fact]
        public void Cannot_Checkout_Empty_Cart()
        {
            //Model
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            Order order = new Order();
            OrderController target = new OrderController(mock.Object, cart);
            //Act
            ViewResult result = target.Checkout(order) as ViewResult;
            //Cheking conditions
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);
        }
        [Fact]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            //Model
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            cart.AddItem(new Book(), 1);
            OrderController target = new OrderController(mock.Object, cart);
            target.ModelState.AddModelError("error", "error");
            //Act
            ViewResult result = target.Checkout(new Order()) as ViewResult;
            //Cheking conditions
            mock.Verify(m=>m.SaveOrder(It.IsAny<Order>()), Times.Never);
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);
        }
        [Fact]
        public void Can_Checkout_And_Submit_Order()
        {
            //Model
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            cart.AddItem(new Book(), 1);
            OrderController target = new OrderController(mock.Object, cart);
            //Act
            RedirectToActionResult result = target.Checkout(new Order()) as RedirectToActionResult;
            //Cheking conditions
            mock.Verify(m=>m.SaveOrder(It.IsAny<Order>()), Times.Once);
            Assert.Equal("Completed", result.ActionName);
        }
    }
}
