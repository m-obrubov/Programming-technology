﻿using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Controllers
{
    public class AddressController : Controller
    {
        private AddressDAO addressDAO = new AddressDAO();
        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        // GET: Address/Details/5
        public ActionResult Details(string id)
        {
            return View(addressDAO.GetById(id));
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(Address address)
        {
            address.UserId = User.Identity.GetUserId();
            if (addressDAO.Create(address))
                return RedirectToAction("Index", "Home");
            else
                return View();
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Address address)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Address address)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}