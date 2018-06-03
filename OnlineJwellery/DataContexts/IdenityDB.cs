using Microsoft.AspNet.Identity.EntityFramework;
using OnlineJwellery.Entities;
using OnlineJwellery.Models;


namespace OnlineJwellery.DataContexts
{
    public class IdenityDB : IdentityDbContext<ApplicationUser>
    {
        public IdenityDB()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static IdenityDB Create()
        {
            return new IdenityDB();
        }
    }
}