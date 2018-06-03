namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ReviewDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "ApplicationUserId");
            AddForeignKey("dbo.Reviews", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "ApplicationUserId" });
            DropColumn("dbo.Reviews", "ApplicationUserId");
            DropColumn("dbo.Reviews", "ReviewDate");
        }
    }
}
