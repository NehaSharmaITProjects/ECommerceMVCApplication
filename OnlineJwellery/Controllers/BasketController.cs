using OnlineJwellery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OnlineJwellery.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult Index()
        { 
            var model = BasketRepository.GetBasket();
            var amount = model.Sum(b => b.Amount);
            ViewBag.TotalAmount = amount;
            //decimal totalamount = 0;
            //foreach (var bas in model) {
            //    totalamount += bas.Amount;
            //}
            return View(model);
        }


        public ActionResult ContinueShopping()
        {
            return RedirectToAction("Index", "Product");
        }

        [Authorize]
        public ActionResult Purchase()
        {

            var currentbasket = BasketRepository.GetBasket();
            var model = BasketRepository.AddtoOrder(currentbasket, User.Identity.GetUserId(), User.Identity.GetUserName());


            return View(model);
            
           
        }
    }
}