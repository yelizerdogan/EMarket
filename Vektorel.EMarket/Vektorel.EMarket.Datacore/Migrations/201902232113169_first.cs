namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Door = c.String(),
                        Building = c.String(),
                        Street = c.String(),
                        Avenue = c.String(),
                        County = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        CustomerKey = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Customers", t => t.CustomerKey)
                .Index(t => t.CustomerKey);
            
            CreateTable(
                "Main.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        IdentityNumber = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Debit = c.Decimal(nullable: false, storeType: "money"),
                        Credit = c.Decimal(nullable: false, storeType: "money"),
                        Balance = c.Decimal(nullable: false, storeType: "money"),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Management.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "Accounting.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Guid(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        CustomerKey = c.Guid(nullable: false),
                        Debit = c.Decimal(nullable: false, storeType: "money"),
                        Credit = c.Decimal(nullable: false, storeType: "money"),
                        Balance = c.Decimal(nullable: false, storeType: "money"),
                        TaxAppliedBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Customers", t => t.CustomerKey, cascadeDelete: true)
                .Index(t => t.CustomerKey);
            
            CreateTable(
                "Accounting.InvoiceLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductKey = c.Guid(nullable: false),
                        UnitType = c.String(),
                        UnitValue = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, storeType: "money"),
                        TotalWithTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Accounting.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("Main.Products", t => t.Product_Id)
                .Index(t => t.InvoiceId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "Main.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false, maxLength: 4000),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Management.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerKey = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "Management.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        FullName = c.String(),
                        LastLogin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PicturePath = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "Management.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "Management.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Product_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("Main.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "Intersections.RoleModules",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ModuleId })
                .ForeignKey("Management.Modules", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Management.Roles", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "Intersections.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Management.Roles", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Management.Users", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Main.Customers", "User_Id", "Management.Users");
            DropForeignKey("Accounting.InvoiceLines", "Product_Id", "Main.Products");
            DropForeignKey("Main.Products", "UserId", "Management.Users");
            DropForeignKey("Intersections.UserRoles", "RoleId", "Management.Users");
            DropForeignKey("Intersections.UserRoles", "UserId", "Management.Roles");
            DropForeignKey("Intersections.RoleModules", "ModuleId", "Management.Roles");
            DropForeignKey("Intersections.RoleModules", "RoleId", "Management.Modules");
            DropForeignKey("dbo.OrderProducts", "Product_Id", "Main.Products");
            DropForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "Main.Customers");
            DropForeignKey("Accounting.InvoiceLines", "InvoiceId", "Accounting.Invoices");
            DropForeignKey("Accounting.Invoices", "CustomerKey", "Main.Customers");
            DropForeignKey("dbo.Addresses", "CustomerKey", "Main.Customers");
            DropIndex("Intersections.UserRoles", new[] { "RoleId" });
            DropIndex("Intersections.UserRoles", new[] { "UserId" });
            DropIndex("Intersections.RoleModules", new[] { "ModuleId" });
            DropIndex("Intersections.RoleModules", new[] { "RoleId" });
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropIndex("Management.Modules", new[] { "Name" });
            DropIndex("Management.Roles", new[] { "Name" });
            DropIndex("Management.Users", new[] { "Email" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("Main.Products", new[] { "UserId" });
            DropIndex("Accounting.InvoiceLines", new[] { "Product_Id" });
            DropIndex("Accounting.InvoiceLines", new[] { "InvoiceId" });
            DropIndex("Accounting.Invoices", new[] { "CustomerKey" });
            DropIndex("Main.Customers", new[] { "User_Id" });
            DropIndex("dbo.Addresses", new[] { "CustomerKey" });
            DropTable("Intersections.UserRoles");
            DropTable("Intersections.RoleModules");
            DropTable("dbo.OrderProducts");
            DropTable("Management.Modules");
            DropTable("Management.Roles");
            DropTable("Management.Users");
            DropTable("dbo.Orders");
            DropTable("Main.Products");
            DropTable("Accounting.InvoiceLines");
            DropTable("Accounting.Invoices");
            DropTable("Main.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
