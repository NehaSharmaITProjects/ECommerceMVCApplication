namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOrder1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Baskets", "Product_Id", "dbo.Products");
            DropIndex("dbo.Baskets", new[] { "Product_Id" });
            AddColumn("dbo.Baskets", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Baskets", "Product_Id1", c => c.Int());
            AlterColumn("dbo.Baskets", "Product_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Baskets", "CustomerId");
            CreateIndex("dbo.Baskets", "Product_Id1");
            AddForeignKey("dbo.Baskets", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Baskets", "Product_Id1", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "Product_Id1", "dbo.Products");
            DropForeignKey("dbo.Baskets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Baskets", new[] { "Product_Id1" });
            DropIndex("dbo.Baskets", new[] { "CustomerId" });
            AlterColumn("dbo.Baskets", "Product_Id", c => c.Int());
            DropColumn("dbo.Baskets", "Product_Id1");
            DropColumn("dbo.Baskets", "CustomerId");
            CreateIndex("dbo.Baskets", "Product_Id");
            AddForeignKey("dbo.Baskets", "Product_Id", "dbo.Products", "Id");
        }
    }
}
