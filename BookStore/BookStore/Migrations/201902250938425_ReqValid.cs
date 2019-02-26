namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReqValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CastomerPhone", c => c.String( maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CastomerPhone", c => c.String(maxLength: 12));
        }
    }
}
