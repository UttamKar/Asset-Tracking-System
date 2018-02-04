namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssetEntries", "AssetEntryDate");
            DropColumn("dbo.CheckIns", "CheckInDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "CheckInDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AssetEntries", "AssetEntryDate", c => c.DateTime(nullable: false));
        }
    }
}
