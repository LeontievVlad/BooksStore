namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cart1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Cart_CartID", c => c.Int());
            CreateIndex("dbo.Books", "Cart_CartID");
            AddForeignKey("dbo.Books", "Cart_CartID", "dbo.Carts", "CartID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Cart_CartID", "dbo.Carts");
            DropIndex("dbo.Books", new[] { "Cart_CartID" });
            DropColumn("dbo.Books", "Cart_CartID");
        }
    }
}
