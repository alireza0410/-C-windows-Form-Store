namespace project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Tcategory = c.String(),
                        Barcode = c.String(),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tools");
        }
    }
}
