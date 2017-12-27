using OnlineShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Controllers
{
    public class ProfileController : Controller
    {
        private BuyerDAO buyerDAO = new BuyerDAO();

        // GET: Profile
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            return View(buyerDAO.GetById(userId));
        }

        public ActionResult Orders()
        {
            string userId = User.Identity.GetUserId();
            return View(new OrderDAO().GetForUserWithDetails(userId));
        }
    }
}