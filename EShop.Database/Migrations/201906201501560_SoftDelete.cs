namespace EShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Brand", c => c.String());
            AddColumn("dbo.Products", "Flavor", c => c.String());
            AddColumn("dbo.Products", "DeletedAtUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Categories", "Description", c => c.String(maxLength: 500));
            DropColumn("dbo.Products", "IsDeleted");
            DropColumn("dbo.Products", "DeletedAtUtc");
            DropColumn("dbo.Products", "Flavor");
            DropColumn("dbo.Products", "Brand");
        }
    }
}
