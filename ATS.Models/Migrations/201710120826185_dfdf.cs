namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetDetails", "Status", c => c.String());
            AlterColumn("dbo.AssetDetails", "EntryDate", c => c.String());
            AlterColumn("dbo.AssetDetails", "AssetEntryId", c => c.Int(nullable: false));
            DropColumn("dbo.AssetDetails", "CheckOutId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetDetails", "CheckOutId", c => c.Int());
            AlterColumn("dbo.AssetDetails", "AssetEntryId", c => c.Int());
            AlterColumn("dbo.AssetDetails", "EntryDate", c => c.DateTime());
            DropColumn("dbo.AssetDetails", "Status");
        }
    }
}
