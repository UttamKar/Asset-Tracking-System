using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.AssetType;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class AssetTypeRepository: CommonRepository<AssetType>, IAssetTypeRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public AssetTypeRepository() : base(new ATSDBContext())
        {
        }

        public List<AssetType> Search(AssetTypeSearchVm model)
        {
            var assetType = Context.AssetTypes.AsQueryable();
            if (!string.IsNullOrEmpty(model.Name))
            {
                assetType = assetType.Where(c => c.Name.ToLower().Contains(model.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.ShortName))
            {
                assetType = assetType.Where(c => c.ShortName.ToLower().Contains(model.ShortName.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.Code))
            {
                assetType = assetType.Where(c => c.Code.ToLower().Contains(model.Code.ToLower()));
            }
            return assetType.ToList();
        }

        public AssetType IsAssetTypeNameExist(string input)
        {
            return Context.AssetTypes.FirstOrDefault(c => c.Name.Equals(input));
        }
    }
}
