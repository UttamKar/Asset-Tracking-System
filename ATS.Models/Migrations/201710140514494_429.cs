namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _429 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CheckInAssetLists", "DueDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CheckInAssetLists", "DueDate", c => c.DateTime(nullable: false));
        }
    }
}
