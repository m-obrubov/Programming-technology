using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private OrderDAO orderDAO = new OrderDAO();

        // GET: Order
        public ActionResult Index()
        {
            return View(orderDAO.GetAll());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View(orderDAO.GetByIdWithDetails(id));
        }

        // GET: Order/Confirm/5
        public ActionResult Confirm(int id)
        {
            return View(orderDAO.GetById(id));
        }

        [HttpPost]
        public ActionResult Confirm(int id, string submitButton)
        {
            if (submitButton == "Confirm")
            {
                orderDAO.UpdateManager(id, User.Identity.GetUserId());
                orderDAO.UpdateStatus(id, OrderStatus.Confirmed);
            }
            else
            {
                orderDAO.UpdateStatus(id, OrderStatus.Cancelled);
            }
            return RedirectToAction("Index");
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                order.Status = (short)OrderStatus.Created;
                string userId = User.Identity.GetUserId();
                order.BuyerId = userId;
                order.ManagerId = "default";
                order.DeliveryAddressId = userId;
                order.IsPayed = false;
                decimal totalCost = 0;
                List<Goods> goodsInOrder = (Session["ShoppingCart"] as LocalShoppingCart).GoodsInCart;
                foreach(Goods goods in goodsInOrder)
                    totalCost += goods.Price;
                order.TotalCost = totalCost;
                Order addedOrder = orderDAO.Create(order);
                if (orderDAO.AddGoodsToOrder(addedOrder, goodsInOrder))
                    Session["ShoppingCart"] = new LocalShoppingCart();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View(orderDAO.GetById(id));
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                Order deletedOrder = orderDAO.GetByIdWithDetails(id);
                orderDAO.Delete(deletedOrder);
                orderDAO.DeleteGoodsFromOrder(order);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
