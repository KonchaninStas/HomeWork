using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Control_V_3.Models;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Control_V_3.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }
        [Authorize]
        public ViewResult List()
        {
            return View(repository.Orders.Where(o => !o.Shipped));
        }
        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderId)
        {
            Order order = repository.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if(order!=null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.Lines.Count()==0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if(ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}