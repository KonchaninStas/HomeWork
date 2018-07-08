using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private IBookRepository repository;
        public NavigationMenuViewComponent(IBookRepository _repository)
        {
            repository = _repository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b));
        }

    }
}
