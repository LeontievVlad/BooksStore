namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WReqValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CastomerPhone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CastomerPhone", c => c.String(nullable: false, maxLength: 12));
        }
    }
}
