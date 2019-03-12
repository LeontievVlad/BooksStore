namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToCom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Name");
        }
    }
}
