using Control_V_3.Models.Entity;
using DataBase.Entity;
using DataBaseIdentityLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Convert
{
    static public class ConvertEntity
    {
        static public Book ConvertToBook(BookEnt bookEnt)
        {
            Book book = new Book
            {
                Author = bookEnt.Author,
                BookId = bookEnt.BookEntId,
                Description = bookEnt.Description,
                Category = bookEnt.Category,
                Count = bookEnt.Count,
                Name = bookEnt.Name,
                Price = bookEnt.Price
            };
            return book;
        }
        static public CartLine ConvertToCartLine(CartLineEnt cartLineEnt)
        {
            CartLine cartLine = new CartLine
            {
                Book = ConvertToBook(cartLineEnt.Book),
            CartLineId=cartLineEnt.CartLineEntId,
            Quantity=cartLineEnt.Quantity
            };
            return cartLine;
        }
        static public Order ConvertToOrder(OrderEnt orderEnt)
        {
            List<CartLine> books = new List<CartLine>();
            foreach(var x in orderEnt.Lines)
            {
                books.Add(ConvertToCartLine(x));
            }
            Order order = new Order
            {
                Address = orderEnt.Address,
                City = orderEnt.City,
                Country = orderEnt.Country,
                GiftWrap = orderEnt.GiftWrap,
                Name = orderEnt.Name,
                OrderId=orderEnt.OrderEntId,
                Shipped=orderEnt.Shipped,
                Surname=orderEnt.Surname,
                Lines=books
            };
            return order;
        }
        static public LoginModel ConvertToLoginModel(LoginModelEnt loginModelEnt)
        {
            LoginModel loginModel = new LoginModel
            {
                Id = loginModelEnt.Id,
                Name = loginModelEnt.Name,
                Password = loginModelEnt.Password,
                ReturnUrl = loginModelEnt.ReturnUrl
            };
            return loginModel;
        }
        static public BookEnt ConvertToBookEnt(Book book)
        {
            BookEnt bookEnt = new BookEnt
            {
                Author = book.Author,
                BookEntId = book.BookId,
                Description = book.Description,
                Category = book.Category,
                Count = book.Count,
                Name = book.Name,
                Price = book.Price
            };
            return bookEnt;
        }
        static public CartLineEnt ConvertToCartLineEnt(CartLine cartLine)
        {
            CartLineEnt cartLineEnt = new CartLineEnt
            {
                Book = ConvertToBookEnt(cartLine.Book),
                CartLineEntId = cartLine.CartLineId,
                Quantity = cartLine.Quantity
            };
            return cartLineEnt;
        }
        static public OrderEnt ConvertToOrderEnt(Order order)
        {
            List<CartLineEnt> booksEnt = new List<CartLineEnt>();
            foreach (var x in order.Lines)
            {
                booksEnt.Add(ConvertToCartLineEnt(x));
            }
            OrderEnt orderEnt = new OrderEnt
            {
                Address = order.Address,
                City = order.City,
                Country = order.Country,
                GiftWrap = order.GiftWrap,
                Name = order.Name,
                OrderEntId = order.OrderId,
                Shipped = order.Shipped,
                Surname = order.Surname,
                Lines = booksEnt
            };
            return orderEnt;
        }
        static public LoginModelEnt ConvertToLoginModelEnt(LoginModel loginModel)
        {
            LoginModelEnt loginModelEnt = new LoginModelEnt
            {
                Id = loginModel.Id,
                Name = loginModel.Name,
                Password = loginModel.Password,
                ReturnUrl = loginModel.ReturnUrl
            };
            return loginModelEnt;
        }
    }
}
