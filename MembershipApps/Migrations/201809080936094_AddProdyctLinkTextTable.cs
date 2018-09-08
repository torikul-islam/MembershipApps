namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProdyctLinkTextTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductLinkText",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductLinkText");
        }
    }
}
