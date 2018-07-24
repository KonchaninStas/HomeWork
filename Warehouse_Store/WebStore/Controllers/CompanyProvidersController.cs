using Entities;
using EntityMethods;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace WebStore.Controllers
{
    public class CompanyProvidersController : Controller
    {
        // GET: CompanyProviders
        public ActionResult Index()
        {
            return View(CompanyProviderMethods.Outpoot().ToList());
        }

        // GET: CompanyProviders/Details/5
        public ActionResult Details(int id)
        {
           CompanyProvider item = CompanyProviderMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: CompanyProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CompanyProvider item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CompanyProviderMethods.AddItem(item);
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

        // GET: CompanyProviders/Edit/5
        public ActionResult Edit(int id)
        {
            CompanyProvider item = CompanyProviderMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: CompanyProviders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyProvider item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CompanyProviderMethods.ChangeItem(item);
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

        // GET: ClientUsers/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(CompanyProviderMethods.GetItem(id));
        }

        // GET: CompanyProviders/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CompanyProviderMethods.DeleteItem(id);
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
