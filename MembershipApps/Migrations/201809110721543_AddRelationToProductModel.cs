namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationToProductModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Product", "ProductLinkTextId");
            CreateIndex("dbo.Product", "ProductTypeId");
            AddForeignKey("dbo.Product", "ProductLinkTextId", "dbo.ProductLinkText", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType");
            DropForeignKey("dbo.Product", "ProductLinkTextId", "dbo.ProductLinkText");
            DropIndex("dbo.Product", new[] { "ProductTypeId" });
            DropIndex("dbo.Product", new[] { "ProductLinkTextId" });
        }
    }
}
