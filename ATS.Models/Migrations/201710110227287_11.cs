namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckIns", "CheckOut_Id", "dbo.CheckOuts");
            DropIndex("dbo.CheckIns", new[] { "CheckOut_Id" });
            DropColumn("dbo.CheckIns", "CheckOut_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "CheckOut_Id", c => c.Int());
            CreateIndex("dbo.CheckIns", "CheckOut_Id");
            AddForeignKey("dbo.CheckIns", "CheckOut_Id", "dbo.CheckOuts", "Id");
        }
    }
}
