namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Cart_CartID", "dbo.Carts");
            DropIndex("dbo.Books", new[] { "Cart_CartID" });
            AddColumn("dbo.Carts", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "BookId");
            AddForeignKey("dbo.Carts", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            DropColumn("dbo.Books", "Cart_CartID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Cart_CartID", c => c.Int());
            DropForeignKey("dbo.Carts", "BookId", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "BookId" });
            DropColumn("dbo.Carts", "BookId");
            CreateIndex("dbo.Books", "Cart_CartID");
            AddForeignKey("dbo.Books", "Cart_CartID", "dbo.Carts", "CartID");
        }
    }
}
