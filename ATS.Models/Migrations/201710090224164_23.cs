namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckIns", "Name", c => c.String());
            DropColumn("dbo.CheckIns", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "Description", c => c.String());
            DropColumn("dbo.CheckIns", "Name");
        }
    }
}
