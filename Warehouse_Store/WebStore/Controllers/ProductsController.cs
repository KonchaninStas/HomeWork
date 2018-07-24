using Entities;
using EntityMethods;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace WebStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View(ProductMethods.Outpoot().ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            Product item = ProductMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET:Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        public ActionResult Create(Product item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductMethods.AddItem(item);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)  
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(item);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product item = ProductMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductMethods.ChangeItem(item);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)  
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(item);
        }

        // GET:Products/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(ProductMethods.GetItem(id));
        }

        // POST: Products/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ProductMethods.DeleteItem(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {
                { "id", id },
                { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}
