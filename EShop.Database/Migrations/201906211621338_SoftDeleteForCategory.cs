namespace EShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDeleteForCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "DeletedAtUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "IsDeleted");
            DropColumn("dbo.Categories", "DeletedAtUtc");
        }
    }
}
