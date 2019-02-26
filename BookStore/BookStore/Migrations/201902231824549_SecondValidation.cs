namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CastomerName", c => c.String());
            AlterColumn("dbo.Orders", "CastomerPhone", c => c.String());
            AlterColumn("dbo.Orders", "CastomerEmail", c => c.String());
            AlterColumn("dbo.Orders", "CastomerAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CastomerAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "CastomerEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "CastomerPhone", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "CastomerName", c => c.String(nullable: false));
        }
    }
}
