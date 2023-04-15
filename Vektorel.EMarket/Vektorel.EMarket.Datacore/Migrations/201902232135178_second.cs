namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Orders", newSchema: "Main");
            MoveTable(name: "dbo.OrderProducts", newSchema: "Intersections");
            DropIndex("Main.Orders", new[] { "Customer_Id" });
            DropColumn("Main.Orders", "CustomerKey");
            RenameColumn(table: "Main.Orders", name: "Customer_Id", newName: "CustomerKey");
            RenameColumn(table: "Intersections.OrderProducts", name: "Order_Id", newName: "ProductId");
            RenameColumn(table: "Intersections.OrderProducts", name: "Product_Id", newName: "OrderId");
            RenameIndex(table: "Intersections.OrderProducts", name: "IX_Order_Id", newName: "IX_ProductId");
            RenameIndex(table: "Intersections.OrderProducts", name: "IX_Product_Id", newName: "IX_OrderId");
            AlterColumn("Main.Orders", "OrderNumber", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("Main.Orders", "OrderTotal", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("Main.Orders", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Main.Orders", "UpdatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Main.Orders", "CustomerKey", c => c.Guid(nullable: false));
            CreateIndex("Main.Orders", "OrderNumber", unique: true);
            CreateIndex("Main.Orders", "CustomerKey");
        }
        
        public override void Down()
        {
            DropIndex("Main.Orders", new[] { "CustomerKey" });
            DropIndex("Main.Orders", new[] { "OrderNumber" });
            AlterColumn("Main.Orders", "CustomerKey", c => c.Guid());
            AlterColumn("Main.Orders", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Main.Orders", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Main.Orders", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("Main.Orders", "OrderNumber", c => c.String());
            RenameIndex(table: "Intersections.OrderProducts", name: "IX_OrderId", newName: "IX_Product_Id");
            RenameIndex(table: "Intersections.OrderProducts", name: "IX_ProductId", newName: "IX_Order_Id");
            RenameColumn(table: "Intersections.OrderProducts", name: "OrderId", newName: "Product_Id");
            RenameColumn(table: "Intersections.OrderProducts", name: "ProductId", newName: "Order_Id");
            RenameColumn(table: "Main.Orders", name: "CustomerKey", newName: "Customer_Id");
            AddColumn("Main.Orders", "CustomerKey", c => c.Guid(nullable: false));
            CreateIndex("Main.Orders", "Customer_Id");
            MoveTable(name: "Intersections.OrderProducts", newSchema: "dbo");
            MoveTable(name: "Main.Orders", newSchema: "dbo");
        }
    }
}
