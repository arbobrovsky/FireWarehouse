namespace FireWarehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIOClient = c.String(),
                        PasportData = c.String(),
                        Sity = c.String(),
                        Adress = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        CreateOnCustomer = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryAndWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        DriverFIO = c.String(),
                        DeliveryMethod = c.String(),
                        Typeofwork = c.String(),
                        Worker1 = c.String(),
                        Worker2 = c.String(),
                        Worker3 = c.String(),
                        Worker4 = c.String(),
                        Worker5 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdressDelivery = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StatusOrder = c.String(),
                        DeliveryAndWork_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.DeliveryAndWorks", t => t.DeliveryAndWork_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.DeliveryAndWork_Id);
            
            CreateTable(
                "dbo.OrderToProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Measure = c.String(),
                        CountProduct = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        NameProduct = c.String(),
                        NameFirma = c.String(),
                        CountProductOnStorehome = c.Single(nullable: false),
                        Measure = c.String(),
                        PriceProduct = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InformationProduct = c.String(),
                        Images = c.String(),
                        ImageScheme = c.String(),
                        ReceiptDate = c.DateTime(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProviderId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        Legaladdress = c.String(),
                        dateProviderProduct = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Prioritet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        FIO = c.String(),
                        Age = c.Int(nullable: false),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.Users");
            DropForeignKey("dbo.OrderToProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.OrderToProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "DeliveryAndWork_Id", "dbo.DeliveryAndWorks");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "ProviderId" });
            DropIndex("dbo.OrderToProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderToProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "DeliveryAndWork_Id" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Users");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.OrderToProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.DeliveryAndWorks");
            DropTable("dbo.Customers");
        }
    }
}
