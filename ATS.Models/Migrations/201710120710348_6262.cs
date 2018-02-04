namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6262 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssetDetails", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.AssetDetails", new[] { "AssetEntryId" });
            AddColumn("dbo.AssetDetails", "EntryDate", c => c.DateTime());
            AddColumn("dbo.AssetDetails", "CheckOutId", c => c.Int());
            AlterColumn("dbo.AssetDetails", "AssetEntryId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssetDetails", "AssetEntryId", c => c.Int(nullable: false));
            DropColumn("dbo.AssetDetails", "CheckOutId");
            DropColumn("dbo.AssetDetails", "EntryDate");
            CreateIndex("dbo.AssetDetails", "AssetEntryId");
            AddForeignKey("dbo.AssetDetails", "AssetEntryId", "dbo.AssetEntries", "Id", cascadeDelete: true);
        }
    }
}
