namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CusName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Orders", "CustomerPhone", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Orders", "CustomerEmail", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Orders", "CustomerAddress", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Orders", "CastomerName");
            DropColumn("dbo.Orders", "CastomerPhone");
            DropColumn("dbo.Orders", "CastomerEmail");
            DropColumn("dbo.Orders", "CastomerAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CastomerAddress", c => c.String());
            AddColumn("dbo.Orders", "CastomerEmail", c => c.String());
            AddColumn("dbo.Orders", "CastomerPhone", c => c.String());
            AddColumn("dbo.Orders", "CastomerName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Orders", "CustomerAddress");
            DropColumn("dbo.Orders", "CustomerEmail");
            DropColumn("dbo.Orders", "CustomerPhone");
            DropColumn("dbo.Orders", "CustomerName");
        }
    }
}
