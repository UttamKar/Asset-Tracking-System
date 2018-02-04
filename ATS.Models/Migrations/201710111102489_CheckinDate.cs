namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckinDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckIns", "CheckInDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckIns", "CheckInDate");
        }
    }
}
