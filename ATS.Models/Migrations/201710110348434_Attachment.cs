namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attachment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        File = c.String(),
                        AssetEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .Index(t => t.AssetEntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.Attachments", new[] { "AssetEntryId" });
            DropTable("dbo.Attachments");
        }
    }
}
