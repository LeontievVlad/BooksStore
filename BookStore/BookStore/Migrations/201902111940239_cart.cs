namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cart : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "NameCart");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "NameCart", c => c.String());
        }
    }
}
