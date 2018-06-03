using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJwellery.Models;
using OnlineJwellery.Entities;

namespace OnlineJwellery.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [OutputCache(Duration =10,VaryByParam ="none")]
        public ActionResult Index()
        {
            var model = ProductRepository.GetProductByPageNumber(0);
            return View(model);
        }
        //[OutputCache(Duration = 60, VaryByParam = "id")]
        public ActionResult Details(int id)
        {

            var model = ProductRepository.GetProduct(id);

            return View(model);
        }
        [HttpGet] // action selector
        public ActionResult Edit(int id)
        {

            var model = ProductRepository.GetProduct(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {

            ProductRepository.SaveProduct(product);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            ProductRepository.DeleteProduct(id);

            return RedirectToAction("Index");
        }
        public ActionResult AddtoCart(int id)
        {

            ProductRepository.AddtoCart(id);

            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult GetProductByPageNumber(int pagenumber)
        {

            var model = ProductRepository.GetProductByPageNumber(pagenumber);

            return View("Index",model);
        }
    }
}