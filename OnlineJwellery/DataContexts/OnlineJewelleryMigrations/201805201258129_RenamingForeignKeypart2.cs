namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingForeignKeypart2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Customer_Id1", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "Product_Id1", "dbo.Products");
            DropIndex("dbo.Addresses", new[] { "Customer_Id1" });
            DropIndex("dbo.Reviews", new[] { "Product_Id1" });
            RenameColumn(table: "dbo.Addresses", name: "Customer_Id1", newName: "CustomerId");
            RenameColumn(table: "dbo.Reviews", name: "Product_Id1", newName: "ProductId");
            AlterColumn("dbo.Addresses", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "CustomerId");
            CreateIndex("dbo.Reviews", "ProductId");
            AddForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.Addresses", "Customer_Id");
            DropColumn("dbo.Reviews", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Product_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "Customer_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            AlterColumn("dbo.Reviews", "ProductId", c => c.Int());
            AlterColumn("dbo.Addresses", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "ProductId", newName: "Product_Id1");
            RenameColumn(table: "dbo.Addresses", name: "CustomerId", newName: "Customer_Id1");
            CreateIndex("dbo.Reviews", "Product_Id1");
            CreateIndex("dbo.Addresses", "Customer_Id1");
            AddForeignKey("dbo.Reviews", "Product_Id1", "dbo.Products", "Id");
            AddForeignKey("dbo.Addresses", "Customer_Id1", "dbo.Customers", "Id");
        }
    }
}
