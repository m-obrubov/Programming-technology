using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserRoleController : Controller
    {
        private UserRoleDAO userRoleDAO = new UserRoleDAO();

        // GET: UserRole
        public ActionResult Index(string id)
        {
            ViewData["userId"] = id;
            return View(userRoleDAO.GetAllForUser(id));
        }

        // GET: UserRole/Add
        public ActionResult Add(string id)
        {
            ViewData["userId"] = id;
            ViewData["roleList"] = new SelectList(userRoleDAO.GetAll(), "Name", "Name");
            return View();
        }

        // POST: UserRole/Add
        [HttpPost]
        public ActionResult Add(string id, AspNetRoles role)
        {
            try
            {
                AspNetRoles addRole = userRoleDAO.GetByName(role.Name);
                userRoleDAO.AddRole(id, addRole);
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }
        

        // GET: UserRole/Delete/5
        public ActionResult Delete(string id, string name)
        {
            return View(userRoleDAO.GetByName(name));
        }

        // POST: UserRole/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, AspNetRoles role)
        {
            try
            {
                userRoleDAO.RemoveRole(id, role);
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}
