using Microsoft.AspNet.Identity;
using OnlineJwellery.Entities;
using OnlineJwellery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJwellery.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            // OrderRepository.AddOrder(); one time run
            ViewBag.Message = "Your app Order page.";
            ViewBag.Location = "Colchester, England";
          /// var model = OrderRepository.GetOrder();
            return View();
        }
        [ActionName("OrderHistory")]
        public ActionResult PreviousOrders()
        {
            var model = OrderRepository.GetPreviousOrders(User.Identity.GetUserId());
            return View("PreviousOrders", model);
        }
        //[HttpPost]
        public ActionResult AddComment(Review review)
        {
            review.ReviewDate = DateTime.Now;
            review.ApplicationUserId = User.Identity.GetUserId();
            OrderRepository.SaveReview(review);

            return RedirectToAction("OrderHistory");
        }

        
    }
}