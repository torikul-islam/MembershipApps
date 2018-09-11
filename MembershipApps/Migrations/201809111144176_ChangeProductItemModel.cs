namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductItemModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ProductItem", "ProductId");
            CreateIndex("dbo.ProductItem", "ItemId");
            AddForeignKey("dbo.ProductItem", "ItemId", "dbo.Item", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductItem", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductItem", "ItemId", "dbo.Item");
            DropIndex("dbo.ProductItem", new[] { "ItemId" });
            DropIndex("dbo.ProductItem", new[] { "ProductId" });
        }
    }
}
