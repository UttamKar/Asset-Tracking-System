namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _32415 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckInAssetLists", "CheckOutAssetList_Id", c => c.Int());
            CreateIndex("dbo.CheckInAssetLists", "CheckOutAssetList_Id");
            AddForeignKey("dbo.CheckInAssetLists", "CheckOutAssetList_Id", "dbo.CheckOutAssetLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckInAssetLists", "CheckOutAssetList_Id", "dbo.CheckOutAssetLists");
            DropIndex("dbo.CheckInAssetLists", new[] { "CheckOutAssetList_Id" });
            DropColumn("dbo.CheckInAssetLists", "CheckOutAssetList_Id");
        }
    }
}
