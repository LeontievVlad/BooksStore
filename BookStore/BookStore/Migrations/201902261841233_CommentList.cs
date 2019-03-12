namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentList : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "ThisBook", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "ThisBook", c => c.Int(nullable: false));
        }
    }
}
