
using OnlineShop.DAO;
using OnlineShop.Models;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        private UserDAO userDAO = new UserDAO();
        // GET: User
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(userDAO.GetAll());
        }

        // GET: User/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            return View(userDAO.GetById(id));
        }

        // GET: User/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return RedirectToAction("RegisterByAdmin", "Account");
        }

        // GET: User/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            return View(userDAO.GetById(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(AspNetUsers user)
        {
            try
            {
                userDAO.Update(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/EditByUser/5
        [Authorize(Roles = "Buyer")]
        public ActionResult EditByUser(string id)
        {
            return View(userDAO.GetById(id));
        }

        // POST: User/EditByUser/5
        [HttpPost]
        [Authorize(Roles = "Buyer")]
        public ActionResult EditByUser(string id, AspNetUsers user)
        {
            userDAO.Update(user);
            return RedirectToAction("Index", "Profile");
        }

        // GET: User/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            return View(userDAO.GetById(id));
        }

        // POST: User/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(AspNetUsers user)
        {
            try
            {
                userDAO.Delete(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }
    }
}
