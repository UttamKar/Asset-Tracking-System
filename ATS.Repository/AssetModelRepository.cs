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
using ATS.Models.Models.ViewModel.AssetModel;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class AssetModelRepository: CommonRepository<AssetModel>, IAssetModelRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext) db; }
        }

        public AssetModelRepository() : base(new ATSDBContext())
        {
        }

        public ICollection<Manufacturer> GetManufacturers(int id)
        {
            return Context.Manufacturers.Where(c => c.AssetGroupId == id).OrderBy(c => c.Name).ToList();
        }

        public List<AssetModel> Search(AssetModelSearchVm model)
        {
            var assetModels = Context.AssetModels.AsQueryable();
            if (model.AssetGroupId !=null)
            {
                assetModels = assetModels.Where(c => c.AssetGroupId==model.AssetGroupId);
            }
            if (model.ManufacturerId != null)
            {
                assetModels = assetModels.Where(c => c.ManufacturerId == model.ManufacturerId);
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                assetModels = assetModels.Where(c => c.Name.ToLower().Contains(model.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.ShortName))
            {
                assetModels = assetModels.Where(c => c.ShortName.ToLower().Contains(model.ShortName.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.Code))
            {
                assetModels = assetModels.Where(c => c.Code.ToLower().Contains(model.Code.ToLower()));
            }
            return assetModels.ToList();
        }
    }
}
