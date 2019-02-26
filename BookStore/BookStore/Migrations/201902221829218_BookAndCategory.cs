namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAndCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "BookId", "dbo.Books");
            DropIndex("dbo.Profiles", new[] { "BookId" });
            DropTable("dbo.Profiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateIndex("dbo.Profiles", "BookId");
            AddForeignKey("dbo.Profiles", "BookId", "dbo.Books", "BookId", cascadeDelete: true);
        }
    }
}
