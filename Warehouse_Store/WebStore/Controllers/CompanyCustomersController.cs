using Entities;
using EntityMethods;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace WebStore.Controllers
{
    public class CompanyCustomersController : Controller
    {
        // GET: CompanyCustomers
        public ActionResult Index()
        {
            return View(CompanyCustomerMethods.Outpoot().ToList());
        }

        // GET: CompanyCustomers/Details/5
        public ActionResult Details(int id)
        {
           CompanyCustomer company = CompanyCustomerMethods.GetItem(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: CompanyCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyCustomers/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CompanyCustomer company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   CompanyCustomerMethods.AddItem(company);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)  
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(company);
        }

        // GET: CompanyCustomers/Edit/5
        public ActionResult Edit(int id)
        {
            CompanyCustomer companyCustomer = CompanyCustomerMethods.GetItem(id);
            if (companyCustomer == null)
            {
                return HttpNotFound();
            }
            return View(companyCustomer);
        }

        // POST: CompanyCustomers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyCustomer company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CompanyCustomerMethods.ChangeItem(company);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)  
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(company);
        }

        // GET: ClientUsers/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(CompanyCustomerMethods.GetItem(id));
        }

        // POST: ClientUsers/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CompanyCustomerMethods.DeleteItem(id);
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
