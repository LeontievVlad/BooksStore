namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IColectionComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Book_BookId", c => c.Int());
            CreateIndex("dbo.Comments", "Book_BookId");
            AddForeignKey("dbo.Comments", "Book_BookId", "dbo.Books", "BookId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Book_BookId", "dbo.Books");
            DropIndex("dbo.Comments", new[] { "Book_BookId" });
            DropColumn("dbo.Comments", "Book_BookId");
        }
    }
}
