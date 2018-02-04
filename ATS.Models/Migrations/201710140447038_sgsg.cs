namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sgsg : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CheckIns", name: "CheckOutAssetListId", newName: "CheckOutAssetList_Id");
            RenameIndex(table: "dbo.CheckIns", name: "IX_CheckOutAssetListId", newName: "IX_CheckOutAssetList_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CheckIns", name: "IX_CheckOutAssetList_Id", newName: "IX_CheckOutAssetListId");
            RenameColumn(table: "dbo.CheckIns", name: "CheckOutAssetList_Id", newName: "CheckOutAssetListId");
        }
    }
}
