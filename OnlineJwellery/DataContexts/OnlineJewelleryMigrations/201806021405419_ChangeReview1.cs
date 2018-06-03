namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReview1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "OrderId");
            AddForeignKey("dbo.Reviews", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "OrderId", "dbo.Orders");
            DropIndex("dbo.Reviews", new[] { "OrderId" });
            DropColumn("dbo.Reviews", "OrderId");
        }
    }
}
