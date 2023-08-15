namespace project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Date2", c => c.DateTime(nullable: false));
            DropColumn("dbo.Carts", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Carts", "Date2");
        }
    }
}
