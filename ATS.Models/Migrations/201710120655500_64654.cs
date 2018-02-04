namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _64654 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AssetDetails", "AssetEntryId");
            AddForeignKey("dbo.AssetDetails", "AssetEntryId", "dbo.AssetEntries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetDetails", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.AssetDetails", new[] { "AssetEntryId" });
        }
    }
}
