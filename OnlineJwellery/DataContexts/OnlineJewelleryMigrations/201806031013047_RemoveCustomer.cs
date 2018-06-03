namespace OnlineJwellery.DataContexts.OnlineJewelleryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            AddColumn("dbo.Addresses", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Addresses", "ApplicationUserId");
            AddForeignKey("dbo.Addresses", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Addresses", "CustomerId");
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Addresses", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Addresses", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Addresses", new[] { "ApplicationUserId" });
            DropColumn("dbo.Addresses", "ApplicationUserId");
            CreateIndex("dbo.Addresses", "CustomerId");
            AddForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
