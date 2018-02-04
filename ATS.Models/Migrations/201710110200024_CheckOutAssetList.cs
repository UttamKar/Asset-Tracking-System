namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckOutAssetList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckInAssetLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetNo = c.String(),
                        Name = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        CheckInId = c.Int(nullable: false),
                        AssetEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckIns", t => t.CheckInId, cascadeDelete: true)
                .Index(t => t.CheckInId);
            
            DropColumn("dbo.CheckIns", "AssetNo");
            DropColumn("dbo.CheckIns", "Name");
            DropColumn("dbo.CheckIns", "DueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "DueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CheckIns", "Name", c => c.String());
            AddColumn("dbo.CheckIns", "AssetNo", c => c.String());
            DropForeignKey("dbo.CheckInAssetLists", "CheckInId", "dbo.CheckIns");
            DropIndex("dbo.CheckInAssetLists", new[] { "CheckInId" });
            DropTable("dbo.CheckInAssetLists");
        }
    }
}
