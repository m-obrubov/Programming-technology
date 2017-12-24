using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.DAO;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class GoodsController : Controller
    {
        GoodsDAO goodsDAO = new GoodsDAO();
        // GET: Goods
        public ActionResult Index()
        {
            return View(goodsDAO.GetAll());
        }

        // GET: Goods
        public ActionResult IndexList()
        {
            return View(goodsDAO.GetAll());
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        [HttpPost]
        public ActionResult Create(Goods goods)
        {
            try
            {
                goodsDAO.Create(goods);
                return RedirectToAction("IndexList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(int id)
        {

            return View(goodsDAO.GetById(id));
        }

        // POST: Goods/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Goods goods)
        {
            try
            {
                goodsDAO.Update(goods);
                return RedirectToAction("IndexList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(int id)
        {
            return View(goodsDAO.GetById(id));
        }

        // POST: Goods/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Goods goods)
        {
            try
            {
                goodsDAO.Delete(goods);
                return RedirectToAction("IndexList");
            }
            catch
            {
                return View();
            }
        }
    }
}
