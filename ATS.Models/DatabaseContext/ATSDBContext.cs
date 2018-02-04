using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Models.Models.UserRelatedModel;
using ATS.Models.Models.ViewModel.SP;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ATS.Models.DatabaseContext
{
    public class ATSDBContext: IdentityDbContext<ApplicationUser>
    {
        public ATSDBContext():base(nameOrConnectionString:"ATSDBContext")
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<AssetGroup> AssetGroups { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AssetModel> AssetModels { get; set; }
        public DbSet<AssetEntry> AssetEntrys { get; set; }

        public static ATSDBContext Create()
        {
            return new ATSDBContext();
        }

        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<CheckInAssetList> CheckInAssetLists { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }
        public DbSet<CheckOutAssetList> CheckOutAssetLists { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AssetDetails> AssetDetailses { get; set; }
        public DbSet<Audit> Audits { get; set; }


        //For AssetList Report
        public ICollection<SP_AssetList> GetAssetListReport(string name)
        {
            var nameParameter = new SqlParameter()
            {
                ParameterName = "Name",
                SqlDbType = SqlDbType.VarChar,
                Value = name ?? (object)DBNull.Value
            };

            var result = Database.SqlQuery<SP_AssetList>("SP_AssetTable @Name", nameParameter);

            return result.ToList();

        }


        //For CheckOut List Report
        public ICollection<SP_CheckOutList> GetCheckOutListReport(string name)
        {
            var nameParameter = new SqlParameter()
            {
                ParameterName = "Name",
                SqlDbType = SqlDbType.VarChar,
                Value = name ?? (object)DBNull.Value
            };

            var result = Database.SqlQuery<SP_CheckOutList>("SP_CheckOutList @Name", nameParameter);

            return result.ToList();

        }
        
    }
}