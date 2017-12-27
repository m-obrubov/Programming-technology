using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.PayService;

namespace OnlineShop.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Online(int id)
        {
            ViewData["orderId"] = id;
            return View();
        }

        // GET: Pay
        [HttpPost]
        public ActionResult Online(int orderId, PurchaseInfo purchase)
        {
            PayServiceSoapClient payService = new PayServiceSoapClient();
            bool payResult = payService.PayOnline(
                    purchase.CardNumber,
                    purchase.ExpYear,
                    purchase.ExpMonth,
                    purchase.CardHolder,
                    purchase.CVC,
                    purchase.Sum
                );
            if(payResult)
                new OrderDAO().UpdateStatus(orderId, OrderStatus.Payed);
            return RedirectToAction("Orders", "Profile");
        }
    }
}