namespace EShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "TotalAmout");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TotalAmout", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "TotalAmount");
            DropColumn("dbo.OrderItems", "Quantity");
        }
    }
}
