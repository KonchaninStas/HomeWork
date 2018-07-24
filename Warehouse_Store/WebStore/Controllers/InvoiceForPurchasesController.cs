using Entities;
using EntityMethods;
using System.Data;
using System.Linq;
using System.Web.Mvc;


namespace WebStore.Controllers
{
    public class InvoiceForPurchasesController : Controller
    {
        // GET: InvoiceForPurchases
        public ActionResult Index()
        {
            return View(InvoiceForPurchaseMethods.Outpoot().ToList());
        }

        // GET: InvoiceForPurchases/Details/5
        public ActionResult Details(int id)
        {
            InvoiceForPurchase item = InvoiceForPurchaseMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: InvoiceForPurchases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceForPurchases/Create
        public ActionResult Create(InvoiceForPurchase item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InvoiceForPurchaseMethods.AddItem(item);
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

        // GET: InvoiceForPurchases/Edit/5
        public ActionResult Edit(int id)
        {
            InvoiceForPurchase item = InvoiceForPurchaseMethods.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: InvoiceForPurchases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvoiceForPurchase item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InvoiceForPurchaseMethods.ChangeItem(item);
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

        // GET:InvoiceForPurchases/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(InvoiceForPurchaseMethods.GetItem(id));
        }

        // POST: InvoiceForPurchases/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                InvoiceForPurchaseMethods.DeleteItem(id);
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
