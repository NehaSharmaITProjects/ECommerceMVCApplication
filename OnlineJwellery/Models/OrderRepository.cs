using OnlineJwellery.DataContexts;
using OnlineJwellery.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineJwellery.Models
{
    public class OrderRepository
    {
        public static void AddOrder()
        {
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
            {
                List<Order> Order1 = new List<Order>();
                for (int i = 10; i < 100; i++)
                {
                    Order addtoList = new Order()
                    {
                       // OdrNum = 10 + i,
                     

                    };
                    Order1.Add(addtoList);
                }
                //_OnlineJewelleryDB.Order.AddRange(Order1);
                _OnlineJewelleryDB.SaveChanges();
            }
        }

        public static void SaveReview(Review review)
        {
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
            {
                _OnlineJewelleryDB.Review.Add(review);
                _OnlineJewelleryDB.SaveChanges();
            }
        }

        //public static List<Order> GetOrder()
        //{
        //    using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
        //    {
        //        return _OnlineJewelleryDB.Order.ToList();
        //    }
        //}

        public static List<Order> GetPreviousOrders(string userid)
        {
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
            {

                //var idParam = new SqlParameter
                //{
                //    ParameterName = "UserId",
                //    Value = userid
                //};

                //var orders = _OnlineJewelleryDB.Database.SqlQuery<Object>("EXEC GetOrderDetails @UserId", idParam).ToList();

                var orders = _OnlineJewelleryDB.Order.Include("OrderItems.Product.Review").Where(ord => ord.ApplicationUserId == userid).OrderByDescending(ord=> ord.OrderPlacedDate).ToList();
             
                return orders;
            }
        }

    }
}