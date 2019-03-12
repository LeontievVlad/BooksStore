namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingN : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "RatingBook");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "RatingBook", c => c.Double(nullable: false));
        }
    }
}
