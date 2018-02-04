namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetEntryDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetEntries", "AssetEntryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssetEntries", "AssetEntryDate");
        }
    }
}
