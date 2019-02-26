namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CastomerName", c => c.String(nullable: false, maxLength: 50));
            
            //AlterColumn("dbo.Orders", "CastomerEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "CastomerAddress", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CastomerAddress", c => c.String());
            AlterColumn("dbo.Orders", "CastomerEmail", c => c.String());
            AlterColumn("dbo.Orders", "CastomerPhone", c => c.String());
            AlterColumn("dbo.Orders", "CastomerName", c => c.String(nullable: false));
        }
    }
}
