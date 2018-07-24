using Entities;
using EntityMethods;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace WebStore.Controllers
{
    public class ClientUsersController : Controller
    {

        // GET: ClientUsers
        public ActionResult Index()
        {
            return View(ClientUserMethods.Outpoot().ToList());
        }

        // GET: ClientUsers/Details/5
        public ActionResult Details(int id)
        {
            ClientUser clientUser = ClientUserMethods.GetItem(id);
            if (clientUser == null)
            {
                return HttpNotFound();
            }
            return View(clientUser);
        }

        // GET: ClientUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientUsers/Create
        [HttpPost]
        public ActionResult Create(ClientUser client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClientUserMethods.AddItem(client);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)  
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(client);
        }

        // GET: ClientUsers/Edit/5
        public ActionResult Edit(int id)
        {
            ClientUser client = ClientUserMethods.GetItem(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        // POST: ClientUsers/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(ClientUser client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClientUserMethods.ChangeItem(client);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)  
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(client);
        }

        // GET: ClientUsers/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            return View(ClientUserMethods.GetItem(id));
        }

        // POST: ClientUsers/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
               ClientUserMethods.DeleteItem(id);
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
