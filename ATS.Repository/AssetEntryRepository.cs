using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel;
using ATS.Models.Models.ViewModel.SP;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class AssetEntryRepository: CommonRepository<AssetEntry>, IAssetEntryRepository
    {
        private ATSDBContext Context
        {
            get { return (ATSDBContext) db; }
        }

        public AssetEntryRepository() : base(new ATSDBContext())
        {
        }




        public ICollection<Branch> GetBranches(int id)
        {
            return Context.Branches.Where(c => c.OrganizationId == id).OrderBy(c => c.Name).ToList();
        }

        public ICollection<Location> GetLocations(int id)
        {
            return Context.Locations.Where(c => c.BranchId == id).OrderBy(c => c.Name).ToList();
        }

        public ICollection<AssetGroup> GetAssetGroups(int id)
        {
            return Context.AssetGroups.Where(c => c.AssetTypeId == id).OrderBy(c => c.Name).ToList();
        }

        public ICollection<Manufacturer> GetManufacturers(int id)
        {
            return Context.Manufacturers.Where(c => c.AssetGroupId == id).OrderBy(c => c.Name).ToList();
        }

        public ICollection<AssetModel> GetModels(int id)
        {
            return Context.AssetModels.Where(c => c.ManufacturerId == id).OrderBy(c => c.Name).ToList();
        }



        //Join Query
        //public ICollection<AssetDetailsVm> GetAssetDetailsVm()
        //{
        //    var result = (from finance in Context.Finances
        //                  join asset in Context.AssetEntrys on finance.AssetEntryId equals asset.Id
        //                  select
        //                      new AssetDetailsVm()
        //                      {
        //                          Id = finance.Id,
        //                          PurchasePrice = finance.PurchasePrice,
        //                          PONo = finance.PONo,
        //                          SerialNo = asset.SerialNo,
        //                          DescriptionName = asset.DescriptionName
        //                      }).ToList();
        //    return result;
        //}
    
        //public ICollection<AssetDetailsVm> GetAssetDetailsVm()
        //{
        //    var result = (from asset in Context.AssetEntrys
        //                  join finance in Context.Finances on asset.Id equals finance.AssetEntryId
        //                  join service in Context.Services on asset.Id equals service.AssetEntryId
        //                  select
        //                      new AssetDetailsVm()
        //                      {
        //                          Id = finance.Id,
        //                          PurchasePrice = finance.PurchasePrice,
        //                          PONo = finance.PONo,
        //                          SerialNo = asset.SerialNo,
        //                          DescriptionName = asset.DescriptionName,
        //                          ServiceingCost = service.ServiceingCost
        //                      }).ToList();
        //    return result;
        //}


        //Report


        public ICollection<SP_AssetList> GetAssetListReport(string name)
        {
            return Context.GetAssetListReport(name);
        }


    }
}
