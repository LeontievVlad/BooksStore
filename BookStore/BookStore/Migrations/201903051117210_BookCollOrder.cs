namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookCollOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Book_BookId", c => c.Int());
            CreateIndex("dbo.Orders", "Book_BookId");
            AddForeignKey("dbo.Orders", "Book_BookId", "dbo.Books", "BookId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Book_BookId", "dbo.Books");
            DropIndex("dbo.Orders", new[] { "Book_BookId" });
            DropColumn("dbo.Orders", "Book_BookId");
        }
    }
}
