namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CastomerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CastomerName", c => c.String());
        }
    }
}
