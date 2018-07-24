using Entities;
using EntityMethods;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace WebStore.Controllers
{
    public class PositionEmployeesController : Controller
    {
        // GET: PositionEmployees
        public ActionResult Index()
        {
            return View(PositionEmployeeMethods.Outpoot().ToList());
        }

        // GET: PositionEmployees/Details/5
        public ActionResult Details(int id)
        {
            PositionEmployee item = PositionEmployeeMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: PositionEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PositionEmployees/Create
        public ActionResult Create(PositionEmployee item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PositionEmployeeMethods.AddItem(item);
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

        // GET: PositionEmployees/Edit/5
        public ActionResult Edit(int id)
        {
            PositionEmployee item = PositionEmployeeMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: PositionEmployees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PositionEmployee item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PositionEmployeeMethods.ChangeItem(item);
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

        // GET:PositionEmployees/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(PositionEmployeeMethods.GetItem(id));
        }

        // POST: PositionEmployees/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PositionEmployeeMethods.DeleteItem(id);
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
