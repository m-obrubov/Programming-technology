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
        [Authorize(Roles = "Buyer")]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            return View(buyerDAO.GetById(userId));
        }

        // GET: Profile/Orders
        [Authorize(Roles = "Buyer")]
        public ActionResult Orders()
        {
            string userId = User.Identity.GetUserId();
            return View(new OrderDAO().GetAllForUserWithDetails(userId));
        }
    }
}