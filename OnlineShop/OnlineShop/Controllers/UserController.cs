
using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        private UserDAO userDAO = new UserDAO();
        // GET: User
        public ActionResult Index()
        {
            return View(userDAO.GetAll());
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            return View(userDAO.GetById(id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return RedirectToAction("Register", "Account");
        }

        [HttpPost]
        public ActionResult Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name, Surname = model.Surname, Birthdate = model.Birthdate, PhoneNumber = model.PhoneNumber };
                var result = new AccountController().UserManager.CreateAsync(user, model.Password);
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            return View(userDAO.GetById(id));
        }

        // POST: User/Edit/5
        [HttpPost]
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

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            return View(userDAO.GetById(id));
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(AspNetUsers user)
        {
            try
            {
                userDAO.Delete(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
