using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Online(int id)
        {
            return View(new OrderDAO().GetById(id));
        }

        // GET: Pay
        [HttpPost]
        public ActionResult Online(Order order)
        {
            //работа с сервисом
            return View();
        }
    }
}