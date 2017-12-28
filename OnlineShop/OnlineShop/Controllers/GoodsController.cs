using OnlineShop.DAO;
using OnlineShop.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

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
        [Authorize(Roles = "Admin")]
        public ActionResult IndexList()
        {
            return View(goodsDAO.GetAll());
        }

        // GET: Goods/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Goods goods, HttpPostedFileBase uploadImage)
        {
            try
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    goods.Image = imageData;
                }
                goodsDAO.Create(goods);
                return RedirectToAction("IndexList");
            }
            catch
            {
                return View();
            }
        }

        public FileContentResult GetImage(int id)
        {
            Goods goods = goodsDAO.GetById(id);
            if (goods != null)
            {
                return File(goods.Image, "image/jpeg");
            }
            else
            {
                return null;
            }
        }

        // GET: Goods/Details/5
        [Authorize(Roles = "Buyer")]
        public ActionResult Details(int id)
        {
            return View(goodsDAO.GetById(id));
        }

        // GET: Goods/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

            return View(goodsDAO.GetById(id));
        }

        // POST: Goods/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Goods goods, HttpPostedFileBase uploadImage)
        {
            try
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    goods.Image = imageData;
                }
                goodsDAO.Update(goods);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(goodsDAO.GetById(id));
        }

        // POST: Goods/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
