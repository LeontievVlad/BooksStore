namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeleteMethod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserEmail", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "UserEmail");
        }
    }
}
