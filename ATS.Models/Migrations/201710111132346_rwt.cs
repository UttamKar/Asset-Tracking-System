namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rwt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssetEntries", "AssetEntryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetEntries", "AssetEntryDate", c => c.DateTime(nullable: false));
        }
    }
}
