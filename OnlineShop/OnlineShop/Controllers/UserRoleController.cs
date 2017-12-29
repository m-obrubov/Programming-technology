using OnlineShop.DAO;
using OnlineShop.Models;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserRoleController : Controller
    {
        private UserRoleDAO userRoleDAO = new UserRoleDAO();

        // GET: UserRole
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string id)
        {
            ViewData["userId"] = id;
            return View(userRoleDAO.GetAllForUser(id));
        }

        // GET: UserRole/Add
        [Authorize(Roles = "Admin")]
        public ActionResult Add(string id)
        {
            ViewData["userId"] = id;
            ViewData["roleList"] = new SelectList(userRoleDAO.GetAll(), "Name", "Name");
            return View();
        }

        // POST: UserRole/Add
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(string id, AspNetRoles role)
        {
            try
            {
                AspNetRoles addRole = userRoleDAO.GetByName(role.Name);
                userRoleDAO.AddRole(id, addRole);
                if (role.Name.Equals("Manager") || role.Name.Equals("Admin"))
                    new EmployeeDAO().Create(id);
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRole/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id, string name)
        {
            return View(userRoleDAO.GetByName(name));
        }

        // POST: UserRole/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id, AspNetRoles role)
        {
            try
            {
                userRoleDAO.RemoveRole(id, role);
                if (role.Name.Equals("Manager") || role.Name.Equals("Admin"))
                    new EmployeeDAO().Delete(id);
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}
