namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityToProductItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductItem", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductItem", "Id");
        }
    }
}
