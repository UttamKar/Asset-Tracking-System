namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reaga : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckIns", "CheckOutAssetListId", "dbo.CheckOutAssetLists");
            DropIndex("dbo.CheckIns", new[] { "CheckOutAssetListId" });
            RenameColumn(table: "dbo.CheckIns", name: "CheckOutAssetListId", newName: "CheckOutAssetList_Id");
            AlterColumn("dbo.CheckIns", "CheckOutAssetList_Id", c => c.Int());
            CreateIndex("dbo.CheckIns", "CheckOutAssetList_Id");
            AddForeignKey("dbo.CheckIns", "CheckOutAssetList_Id", "dbo.CheckOutAssetLists", "Id");
            DropColumn("dbo.CheckIns", "AssetEntryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "AssetEntryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CheckIns", "CheckOutAssetList_Id", "dbo.CheckOutAssetLists");
            DropIndex("dbo.CheckIns", new[] { "CheckOutAssetList_Id" });
            AlterColumn("dbo.CheckIns", "CheckOutAssetList_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CheckIns", name: "CheckOutAssetList_Id", newName: "CheckOutAssetListId");
            CreateIndex("dbo.CheckIns", "CheckOutAssetListId");
            AddForeignKey("dbo.CheckIns", "CheckOutAssetListId", "dbo.CheckOutAssetLists", "Id", cascadeDelete: true);
        }
    }
}
