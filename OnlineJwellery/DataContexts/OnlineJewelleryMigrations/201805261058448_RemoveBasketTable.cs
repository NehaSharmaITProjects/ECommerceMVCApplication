namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBasketTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Baskets", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Baskets", "ProductId", "dbo.Products");
            DropIndex("dbo.Baskets", new[] { "UserId" });
            DropIndex("dbo.Baskets", new[] { "ProductId" });
            DropTable("dbo.Baskets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateIndex("dbo.Baskets", "ProductId");
            CreateIndex("dbo.Baskets", "UserId");
            AddForeignKey("dbo.Baskets", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Baskets", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
