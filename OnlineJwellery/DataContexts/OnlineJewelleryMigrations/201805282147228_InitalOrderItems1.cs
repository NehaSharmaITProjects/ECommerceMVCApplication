namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalOrderItems1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Order_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.OrderItems", "Order_UserId");
            AddForeignKey("dbo.OrderItems", "Order_UserId", "dbo.Orders", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_UserId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_UserId" });
            DropColumn("dbo.OrderItems", "Order_UserId");
        }
    }
}
