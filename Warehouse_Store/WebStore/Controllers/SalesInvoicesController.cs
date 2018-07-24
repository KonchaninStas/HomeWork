using Entities;
using EntityMethods;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace WebStore.Controllers
{
    public class SalesInvoicesController : Controller
    {
        // GET: SalesInvoice
        public ActionResult Index()
        {
            return View(SalesInvoiceMethods.Outpoot().ToList());
        }

        // GET: SalesInvoices/Details/5
        public ActionResult Details(int id)
        {
            SalesInvoice item = SalesInvoiceMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: SalesInvoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesInvoices/Create
        public ActionResult Create(SalesInvoice item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SalesInvoiceMethods.AddItem(item);
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

        // GET: SalesInvoices/Edit/5
        public ActionResult Edit(int id)
        {
            SalesInvoice item = SalesInvoiceMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: SalesInvoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesInvoice item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SalesInvoiceMethods.ChangeItem(item);
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

        // GET:SalesInvoices/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(SalesInvoiceMethods.GetItem(id));
        }

        // POST: SalesInvoices/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SalesInvoiceMethods.DeleteItem(id);
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
