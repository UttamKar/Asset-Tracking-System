namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21345 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CheckIns", name: "CheckOutAssetList_Id", newName: "CheckOutAssetListId");
            RenameIndex(table: "dbo.CheckIns", name: "IX_CheckOutAssetList_Id", newName: "IX_CheckOutAssetListId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CheckIns", name: "IX_CheckOutAssetListId", newName: "IX_CheckOutAssetList_Id");
            RenameColumn(table: "dbo.CheckIns", name: "CheckOutAssetListId", newName: "CheckOutAssetList_Id");
        }
    }
}
