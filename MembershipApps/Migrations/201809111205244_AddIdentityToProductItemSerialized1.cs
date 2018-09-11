namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityToProductItemSerialized1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductItem");
            AddPrimaryKey("dbo.ProductItem", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProductItem");
            AddPrimaryKey("dbo.ProductItem", new[] { "ProductId", "ItemId" });
        }
    }
}
