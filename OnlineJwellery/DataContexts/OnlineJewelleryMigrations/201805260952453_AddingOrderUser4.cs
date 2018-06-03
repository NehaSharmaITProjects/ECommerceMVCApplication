namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOrderUser4 : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.Baskets", "UserId", c => c.Int());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Baskets", "UserId");
        }
    }
}
