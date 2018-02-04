namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _43535 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetDetails", "EmployeeId", c => c.Int());
            AlterColumn("dbo.AssetDetails", "AssetEntryId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssetDetails", "AssetEntryId", c => c.Int(nullable: false));
            DropColumn("dbo.AssetDetails", "EmployeeId");
        }
    }
}
