﻿using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            LocalShoppingCart cart = (LocalShoppingCart)Session["ShoppingCart"];
            return View(cart.GoodsInCart);
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            return Add(id);
        }
        
        public ActionResult Add(int id)
        {
            LocalShoppingCart cart = (LocalShoppingCart)Session["ShoppingCart"];
            Goods goodsToAdd = new GoodsDAO().GetById(id);
            cart.AddToCart(goodsToAdd);
            return RedirectToAction("Index", "Home");
        }
        
        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            Goods goodsToRemove = new GoodsDAO().GetById(id);
            return View(goodsToRemove);
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Goods goods)
        {
            try
            {
                LocalShoppingCart cart = (LocalShoppingCart)Session["ShoppingCart"];
                cart.RemoveFromCart(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}