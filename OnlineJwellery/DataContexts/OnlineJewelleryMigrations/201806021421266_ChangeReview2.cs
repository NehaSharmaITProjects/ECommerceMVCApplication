namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReview2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderItems", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
