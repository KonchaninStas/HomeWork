using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Control_V_3.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IBookRepository repository;
        public AdminController(IBookRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index()
        {
            return View(repository.Books);
        }
        public ViewResult Edit(int bookId)
        {
            return View(repository.Books.FirstOrDefault(b => b.BookId == bookId));
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if(ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = $"{book.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
        public ViewResult Create ()
        {
            return View("Edit", new Book());
        }
        [HttpPost]
        public IActionResult Delete(int bookId)
        {
            Book deletedBook = repository.DeleteBook(bookId);
            if(deletedBook!=null)
                {
                TempData["message"] = $"{deletedBook.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}