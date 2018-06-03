namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineJwellery.DataContexts.OnlineJewelleryDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\OnlineJewelleryMigrations";
        }

        protected override void Seed(OnlineJwellery.DataContexts.OnlineJewelleryDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
