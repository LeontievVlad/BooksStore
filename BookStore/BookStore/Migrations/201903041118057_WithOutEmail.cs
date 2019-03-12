namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithOutEmail : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "UserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserEmail", c => c.String(maxLength: 50));
        }
    }
}
