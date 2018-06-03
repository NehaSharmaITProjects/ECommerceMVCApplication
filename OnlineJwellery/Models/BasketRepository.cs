using OnlineJwellery.DataContexts;
using OnlineJwellery.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineJwellery.Models
{
    public class BasketRepository
    {
        public static List<Basket> GetBasket()
        {
            List<Basket> ListBasket;
            if (HttpContext.Current.Session["Basket"] != null)
            {
                ListBasket = HttpContext.Current.Session["Basket"] as List<Basket>;
            }
            else
            {
                ListBasket = new List<Basket>();
            }

            return ListBasket;
        }

        public static void ClearBasket()
        {
       
            if (HttpContext.Current.Session["Basket"] != null)
            {
                HttpContext.Current.Session.Remove("Basket");
            }                    
        }


        public static void AddtoBasket(Product product,int quantity )
        {
            List<Basket> ListBasket = GetBasket();
            Basket MyshoppingBag = new Basket()
            {
                Product = product,
                Quantity = quantity
            };

            Basket ProductAlreadyInbasket = ListBasket.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (ProductAlreadyInbasket != null) {
                ProductAlreadyInbasket.Quantity += 1; // if already product was previously added increase its quantity
            } else
                ListBasket.Add(MyshoppingBag);

            HttpContext.Current.Session["Basket"] = ListBasket;
        }
        public static Order AddtoOrder(List<Basket> ListBasket, string userid, string username)
        {
            using (OnlineJewelleryDB _onlineDB = new OnlineJewelleryDB())
            {
                List<OrderItems> ListOrderitems = new List<OrderItems>();

                Order orderplace = new Order()
                {
                    OdrNum = Guid.NewGuid().ToString("N"),
                    OrderPlacedDate = DateTime.Now,
                    ApplicationUserId = userid,
                    UserName = username,
                    OrderItems = ListOrderitems
                };
                _onlineDB.Order.Add(orderplace);

                _onlineDB.SaveChanges();

               
                foreach (var basket in ListBasket)
                {
                    OrderItems Orderhere = new OrderItems()
                    {
                        //Product = basket.Product,             
                        Quantity = basket.Quantity,
                        ProductId = basket.Product.Id,
                        OrderId = orderplace.Id

                    };
                    var product = _onlineDB.Product.Find(basket.Product.Id);
                    product.Quantity = product.Quantity - basket.Quantity; // reduce the stock 
                    _onlineDB.Entry(product).State = EntityState.Modified;

                    ListOrderitems.Add(Orderhere);
                }

                

                _onlineDB.OrderItems.AddRange(ListOrderitems);

                _onlineDB.SaveChanges();


                ClearBasket();

                // get the saved order back to display to the user
               var orderplaceDB = _onlineDB.Order.Include("OrderItems.Product").Where(ord => ord.Id == orderplace.Id).FirstOrDefault();

                return orderplaceDB;
            }
        }

    }
}