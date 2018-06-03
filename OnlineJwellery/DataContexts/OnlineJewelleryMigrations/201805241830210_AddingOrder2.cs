namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOrder2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Baskets", "Product_Id1", "dbo.Products");
            DropIndex("dbo.Baskets", new[] { "Product_Id1" });
            RenameColumn(table: "dbo.Baskets", name: "Product_Id1", newName: "ProductId");
            AlterColumn("dbo.Baskets", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Baskets", "ProductId");
            AddForeignKey("dbo.Baskets", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.Baskets", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Baskets", "Product_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Baskets", "ProductId", "dbo.Products");
            DropIndex("dbo.Baskets", new[] { "ProductId" });
            AlterColumn("dbo.Baskets", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Baskets", name: "ProductId", newName: "Product_Id1");
            CreateIndex("dbo.Baskets", "Product_Id1");
            AddForeignKey("dbo.Baskets", "Product_Id1", "dbo.Products", "Id");
        }
    }
}
