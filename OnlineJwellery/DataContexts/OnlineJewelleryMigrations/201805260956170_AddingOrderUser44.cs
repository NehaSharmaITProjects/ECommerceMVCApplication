namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOrderUser44 : DbMigration
    {
        public override void Up()
        {
           // AlterColumn("dbo.Baskets", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
          //  AlterColumn("dbo.Baskets", "UserId", c => c.String());
        }
    }
}
