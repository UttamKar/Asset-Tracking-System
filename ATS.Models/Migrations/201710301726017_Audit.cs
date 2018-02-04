namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Audit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetOk = c.Boolean(nullable: false),
                        AssetOnLocation = c.Boolean(nullable: false),
                        AssetUnderCustodian = c.Boolean(nullable: false),
                        Comment = c.String(),
                        AuditDate = c.DateTime(nullable: false),
                        AssetEntryId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audits");
        }
    }
}
