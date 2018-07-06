using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Control_V_3.Models;
using Control_V_3.Models.Repository;
using Control_V_3.Models.ViewModels;

namespace Control_V_3.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;
        public int PageSize = 4;
        //private ApplicationContext context;
        //public BookController(ApplicationContext _context)
        //{
        //    context = _context;
        //}
        public BookController(IBookRepository rep)
        {
            repository = rep;
        }
        public ViewResult List(string category, int page=1)
        {
            return View (new BooksListViewModel
            {
                Books = repository.Books
                .Where(b => b.Category == null || b.Category.Name == category)
               .OrderBy(b => b.BookId)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),
                PadingInfo = new PadingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Books.Count()
                },
                CurrentCategory=category
            });
        }
    }
}
