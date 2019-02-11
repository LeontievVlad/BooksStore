namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        NameCart = c.String(),
                        SumCart = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CartID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}
