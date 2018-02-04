namespace ATS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        SerialNo = c.String(),
                        DescriptionName = c.String(),
                        Status = c.String(),
                        Attachment = c.String(),
                        LocationId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        AssetModelId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        AssetGroupId = c.Int(nullable: false),
                        AssetTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetModels", t => t.AssetModelId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.AssetModelId);
            
            CreateTable(
                "dbo.AssetModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        ManufacturerId = c.Int(nullable: false),
                        AssetGroupId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        AssetGroupId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetGroups", t => t.AssetGroupId, cascadeDelete: true)
                .Index(t => t.AssetGroupId);
            
            CreateTable(
                "dbo.AssetGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        AssetTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetTypes", t => t.AssetTypeId, cascadeDelete: true)
                .Index(t => t.AssetTypeId);
            
            CreateTable(
                "dbo.AssetTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Finances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchasePrice = c.String(),
                        PONo = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        VendorId = c.Int(nullable: false),
                        AssetEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .Index(t => t.AssetEntryId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        Department = c.String(),
                        Designation = c.String(),
                        Address = c.String(),
                        Code = c.String(),
                        Image = c.String(),
                        BranchId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.CheckOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeNo = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        CheckOutFor = c.String(),
                        Comments = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.CheckOutAssetLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetNo = c.String(),
                        Name = c.String(),
                        CheckOutId = c.Int(nullable: false),
                        AssetEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckOuts", t => t.CheckOutId, cascadeDelete: true)
                .Index(t => t.CheckOutId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryNotes = c.String(),
                        AssetEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .Index(t => t.AssetEntryId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ServiceingCost = c.String(),
                        ServiceDate = c.DateTime(nullable: false),
                        PartsCost = c.String(),
                        ServiceBy = c.String(),
                        Tax = c.String(),
                        AssetEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .Index(t => t.AssetEntryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Designation = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        Comments = c.String(),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Services", "AssetEntryId", "dbo.AssetEntries");
            DropForeignKey("dbo.Notes", "AssetEntryId", "dbo.AssetEntries");
            DropForeignKey("dbo.Locations", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.CheckOuts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CheckOutAssetLists", "CheckOutId", "dbo.CheckOuts");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.AssetEntries", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Finances", "AssetEntryId", "dbo.AssetEntries");
            DropForeignKey("dbo.AssetEntries", "AssetModelId", "dbo.AssetModels");
            DropForeignKey("dbo.AssetModels", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Manufacturers", "AssetGroupId", "dbo.AssetGroups");
            DropForeignKey("dbo.AssetGroups", "AssetTypeId", "dbo.AssetTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Services", new[] { "AssetEntryId" });
            DropIndex("dbo.Notes", new[] { "AssetEntryId" });
            DropIndex("dbo.CheckOutAssetLists", new[] { "CheckOutId" });
            DropIndex("dbo.CheckOuts", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "OrganizationId" });
            DropIndex("dbo.Locations", new[] { "BranchId" });
            DropIndex("dbo.Finances", new[] { "AssetEntryId" });
            DropIndex("dbo.AssetGroups", new[] { "AssetTypeId" });
            DropIndex("dbo.Manufacturers", new[] { "AssetGroupId" });
            DropIndex("dbo.AssetModels", new[] { "ManufacturerId" });
            DropIndex("dbo.AssetEntries", new[] { "AssetModelId" });
            DropIndex("dbo.AssetEntries", new[] { "LocationId" });
            DropTable("dbo.Vendors");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Services");
            DropTable("dbo.Notes");
            DropTable("dbo.Organizations");
            DropTable("dbo.CheckOutAssetLists");
            DropTable("dbo.CheckOuts");
            DropTable("dbo.Employees");
            DropTable("dbo.Branches");
            DropTable("dbo.Locations");
            DropTable("dbo.Finances");
            DropTable("dbo.AssetTypes");
            DropTable("dbo.AssetGroups");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.AssetModels");
            DropTable("dbo.AssetEntries");
        }
    }
}
