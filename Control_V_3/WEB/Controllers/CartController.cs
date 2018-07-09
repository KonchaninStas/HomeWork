using System.Linq;
using Control_V_3.Models;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Control_V_3.Infrastructure;
using Control_V_3.Models.ViewModels;

namespace Control_V_3.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository repository;
        private Cart cart;
        public CartController(IBookRepository rep, Cart _cart)
        {
            repository = rep;
            cart = _cart;
        }
        public ViewResult Index (string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl=returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            if(book!=null)
            {
                cart.AddItem(book, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            if(book!=null)
            {
                cart.RemoveLine(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}