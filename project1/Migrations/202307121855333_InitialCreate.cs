namespace project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        PhoneNumber = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SumPrice = c.Double(nullable: false),
                        customer_id = c.Int(),
                        factor_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .ForeignKey("dbo.Factors", t => t.factor_id)
                .Index(t => t.customer_id)
                .Index(t => t.factor_id);
            
            CreateTable(
                "dbo.Factors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FacNumber = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        RAM = c.Int(nullable: false),
                        Cpu = c.String(),
                        Size = c.String(),
                        Barcode = c.String(),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        Cart_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Carts", t => t.Cart_id)
                .Index(t => t.Cart_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mobiles", "Cart_id", "dbo.Carts");
            DropForeignKey("dbo.Carts", "factor_id", "dbo.Factors");
            DropForeignKey("dbo.Carts", "customer_id", "dbo.Customers");
            DropIndex("dbo.Mobiles", new[] { "Cart_id" });
            DropIndex("dbo.Carts", new[] { "factor_id" });
            DropIndex("dbo.Carts", new[] { "customer_id" });
            DropTable("dbo.Mobiles");
            DropTable("dbo.Factors");
            DropTable("dbo.Carts");
            DropTable("dbo.Customers");
        }
    }
}
