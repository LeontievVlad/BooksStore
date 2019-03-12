namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "RatingBook", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "RatingBook");
        }
    }
}
