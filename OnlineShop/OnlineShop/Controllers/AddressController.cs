using Microsoft.AspNet.Identity;
using OnlineShop.DAO;
using OnlineShop.Models;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class AddressController : Controller
    {
        private AddressDAO addressDAO = new AddressDAO();

        // GET: Address/Create
        [Authorize(Roles = "Buyer")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        [Authorize(Roles = "Buyer")]
        public ActionResult Create(Address address)
        {
            address.UserId = User.Identity.GetUserId();
            if (addressDAO.Create(address))
                return RedirectToAction("Index", "Home");
            else
                return View();
        }

        // GET: Address/Edit/5
        [Authorize(Roles = "Buyer")]
        public ActionResult Edit(string id)
        {
            return View(addressDAO.GetById(id));
        }

        // POST: Address/Edit/5
        [HttpPost]
        [Authorize(Roles = "Buyer")]
        public ActionResult Edit(Address address)
        {
            addressDAO.Update(address);
            return RedirectToAction("Index", "Profile");
        }
    }
}
