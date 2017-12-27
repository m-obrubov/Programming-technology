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
        public ActionResult Online(int id, decimal sum)
        {
            ViewData["orderId"] = id;
            PurchaseInfo info = new PurchaseInfo { Sum = sum };
            return View(info);
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
            {
                OrderDAO orderDAO = new OrderDAO();
                orderDAO.UpdateStatus(orderId, OrderStatus.Payed);
                orderDAO.UpdateIsPayed(orderId, true);
            }
                
            return RedirectToAction("Orders", "Profile");
        }
    }
}