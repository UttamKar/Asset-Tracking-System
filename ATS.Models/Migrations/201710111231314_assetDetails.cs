namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assetDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNo = c.String(),
                        DescriptionName = c.String(),
                        AssetEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .Index(t => t.AssetEntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetDetails", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.AssetDetails", new[] { "AssetEntryId" });
            DropTable("dbo.AssetDetails");
        }
    }
}
