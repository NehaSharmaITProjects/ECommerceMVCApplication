namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOrderUser441 : DbMigration
    {
        public override void Up()
        {

            AlterColumn("dbo.Baskets", "Id", c => c.Int(nullable: false));
   
          
        }
        
        public override void Down()
        {
          
        }
    }
}
