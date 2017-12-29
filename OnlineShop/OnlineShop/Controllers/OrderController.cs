using Microsoft.AspNet.Identity;
using OnlineShop.DAO;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private OrderDAO orderDAO = new OrderDAO();

        // GET: Order
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Index()
        {
            return View(orderDAO.GetAll());
        }

        // GET: Order/Details/5
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Details(int id)
        {
            return View(orderDAO.GetByIdWithDetails(id));
        }

        // GET: Order/Confirm/5
        [Authorize(Roles = "Manager")]
        public ActionResult Confirm(int id)
        {
            return View(orderDAO.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
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

        // GET: Order/Send
        [Authorize(Roles = "Manager")]
        public ActionResult Send(int id)
        {
            return View(orderDAO.GetById(id));
        }

        // POST: Order/Send
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult Send(Order order)
        {
            orderDAO.UpdateStatus(order.Id, OrderStatus.Delivering);
            return RedirectToAction("Index");
        }

        // GET: Order/ConfirmDelivering
        [Authorize(Roles = "Buyer")]
        public ActionResult ConfirmDelivering(int id)
        {
            return View(orderDAO.GetById(id));
        }

        // POST: Order/ConfirmDelivering
        [HttpPost]
        [Authorize(Roles = "Buyer")]
        public ActionResult ConfirmDelivering(Order order)
        {
            orderDAO.UpdateStatus(order.Id, OrderStatus.Done);
            return RedirectToAction("Index", "Profile");
        }

        // GET: Order/ConfirmDelivering
        [Authorize(Roles = "Buyer")]
        public ActionResult Cancel(int id)
        {
            return View(orderDAO.GetById(id));
        }

        // POST: Order/ConfirmDelivering
        [HttpPost]
        [Authorize(Roles = "Buyer")]
        public ActionResult Cancel(Order order)
        {
            orderDAO.UpdateStatus(order.Id, OrderStatus.Cancelled);
            return RedirectToAction("Index", "Profile");
        }

        // GET: Order/Create
        [Authorize(Roles = "Buyer")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [Authorize(Roles = "Buyer")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(orderDAO.GetById(id));
        }

        // POST: Order/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                Order deletedOrder = orderDAO.GetByIdWithDetails(id);
                orderDAO.DeleteGoodsFromOrder(deletedOrder);
                orderDAO.Delete(deletedOrder);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
