namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropIndex("dbo.Addresses", new[] { "Customer_Id" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            RenameColumn(table: "dbo.Reviews", name: "ProductId", newName: "Product_Id1");
            AddColumn("dbo.Addresses", "Customer_Id1", c => c.Int());
            AddColumn("dbo.Reviews", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "Customer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "Product_Id1", c => c.Int());
            CreateIndex("dbo.Addresses", "Customer_Id1");
            CreateIndex("dbo.Reviews", "Product_Id1");
            AddForeignKey("dbo.Addresses", "Customer_Id1", "dbo.Customers", "Id");
            AddForeignKey("dbo.Reviews", "Product_Id1", "dbo.Products", "Id");
            DropColumn("dbo.Addresses", "CustId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "CustId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "Product_Id1", "dbo.Products");
            DropForeignKey("dbo.Addresses", "Customer_Id1", "dbo.Customers");
            DropIndex("dbo.Reviews", new[] { "Product_Id1" });
            DropIndex("dbo.Addresses", new[] { "Customer_Id1" });
            AlterColumn("dbo.Reviews", "Product_Id1", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "Customer_Id", c => c.Int());
            DropColumn("dbo.Reviews", "Product_Id");
            DropColumn("dbo.Addresses", "Customer_Id1");
            RenameColumn(table: "dbo.Reviews", name: "Product_Id1", newName: "ProductId");
            CreateIndex("dbo.Reviews", "ProductId");
            CreateIndex("dbo.Addresses", "Customer_Id");
            AddForeignKey("dbo.Reviews", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
