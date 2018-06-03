namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOrderUser2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Baskets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Baskets", new[] { "CustomerId" });
            DropColumn("dbo.Baskets", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Baskets", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Baskets", "CustomerId");
            AddForeignKey("dbo.Baskets", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
