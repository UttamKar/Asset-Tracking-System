namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssetDetails", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.AssetDetails", new[] { "AssetEntryId" });
            DropColumn("dbo.AssetDetails", "AssetEntryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetDetails", "AssetEntryId", c => c.Int(nullable: false));
            CreateIndex("dbo.AssetDetails", "AssetEntryId");
            AddForeignKey("dbo.AssetDetails", "AssetEntryId", "dbo.AssetEntries", "Id", cascadeDelete: true);
        }
    }
}
