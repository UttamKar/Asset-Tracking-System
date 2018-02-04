using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.AssetGroup;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class AssetGroupRepository: CommonRepository<AssetGroup>, IAssetGroupRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public AssetGroupRepository() : base(new ATSDBContext())
        {
        }



        public List<AssetGroup> Search(AssetGroupSearchVm model)
        {
            var assets = Context.AssetGroups.AsQueryable();
            if (model.AssetTypeId != null)
            {
                assets = assets.Where(c => c.AssetTypeId == model.AssetTypeId);
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                assets = assets.Where(c => c.Name.ToLower().Contains(model.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.ShortName))
            {
                assets = assets.Where(c => c.ShortName.ToLower().Contains(model.ShortName.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.Code))
            {
                assets = assets.Where(c => c.Code.ToLower().Contains(model.Code.ToLower()));
            }
            return assets.ToList();
        }

        public AssetGroup IsAssetTypeNameExist(string input)
        {
            return Context.AssetGroups.FirstOrDefault(c => c.Name.Equals(input));
        }
    }
}
