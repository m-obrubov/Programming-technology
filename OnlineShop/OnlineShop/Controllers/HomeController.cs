using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            ApplicationEntitiesDbContext dbContext = ApplicationEntitiesDbContext.Create();
            dbContext.Addresses.Add(new Address
            {
                Postcode = "12312312",
                Country = "12312312",
                Region = "12312312",
                City = "12312312",
                Street = "12312312",
                House = "12312312",
                Flat = "12312312"
            });
            dbContext.SaveChanges();
            return View();
        }

        public ActionResult Contact()
        {
            ApplicationEntitiesDbContext dbContext = ApplicationEntitiesDbContext.Create();
            string text = "";
            var users = dbContext.Users;
            foreach(var user in users)
            {
                text += user.Name + '\n';
            }
            ViewBag.Message = text;

            return View();
        }
    }
}