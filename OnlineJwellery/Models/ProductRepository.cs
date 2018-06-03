using OnlineJwellery.DataContexts;
using OnlineJwellery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJwellery.Models
{
    public class ProductRepository
    {
        public static List<Product> GetProduct()
        {
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB()) {
                return _OnlineJewelleryDB.Product.ToList();
            }                 
        }

        public static List<Product> GetProductByPageNumber(int pagenumber)
        {
            //return GetProduct().Skip(pagenumber * 9).Take(9).ToList();
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
            {
                return _OnlineJewelleryDB.Product.AsNoTracking().ToList().Skip(pagenumber * 9).Take(9).ToList();
            }
        }

        public static Product GetProduct(int productId)
        {
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
            {
                return _OnlineJewelleryDB.Product.Include("Review").Where(p=>p.Id==productId).FirstOrDefault();
            }
        }
        public static void SaveProduct(Product product )
        {
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
            {
                _OnlineJewelleryDB.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _OnlineJewelleryDB.SaveChanges();
            }
        }
        public static void AddtoCart(int productId)
        {
            var product = GetProduct(productId);
            BasketRepository.AddtoBasket(product, 1);
        }

        public static void DeleteProduct(int productId)
        {
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
            {
          
                 var product = GetProduct(productId);
                //_OnlineJewelleryDB.Product.Remove(product);
                _OnlineJewelleryDB.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                _OnlineJewelleryDB.SaveChanges();
            }
        }
        public static void AddProduct()
        {
            using (OnlineJewelleryDB _OnlineJewelleryDB = new OnlineJewelleryDB())
            {
                List<Product> Product1 = new List<Product>();
                for(int i = 2; i < 100; i++)
                {
                        Product addtolist = new Product()
                        {
                            Name = "Product" + i,
                            Description = "asdsh",
                            Price = 100*i,
                            Quantity = 10+i,
                            InStore = i%2==0
                        };
                    Product1.Add(addtolist);
                }
                _OnlineJewelleryDB.Product.AddRange(Product1);
                _OnlineJewelleryDB.SaveChanges();
            }
        }
    }
}