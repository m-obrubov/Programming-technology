﻿
using OnlineShop.DAO;
using OnlineShop.Models;
using System.Web.Mvc;

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
            return RedirectToAction("RegisterByAdmin", "Account");
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