using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineJwellery.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineJwellery.DataContexts
{
    public class OnlineJewelleryDB : IdentityDbContext
    {
        public OnlineJewelleryDB(): base("DefaultConnection")
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Review> Review { get; set; }
        //public DbSet<Basket> Basket { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }


    }
}