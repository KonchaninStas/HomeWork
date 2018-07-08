using Control_V_3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cart)
        {
            this.cart = cart;
        }
        public IViewComponentResult Invoke ()
        {
            return View(cart);
        }
    }
}
