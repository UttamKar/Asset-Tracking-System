namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _99 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetDetails", "AssetEntryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssetDetails", "AssetEntryId");
        }
    }
}
