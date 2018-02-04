using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel;
using ATS.Models.Models.ViewModel.SP;
using ATS.Repository;

namespace ATS.BLL
{
    public class AssetEntryManager: CommonManager<AssetEntry>, IAssetEntryManager
    {
        private IAssetEntryRepository _assetEntryRepository;
        public AssetEntryManager() : base(new AssetEntryRepository())
        {
            _assetEntryRepository = base._repository as IAssetEntryRepository;
        }

        public ICollection<Branch> GetBranches(int id)
        {
            return _assetEntryRepository.GetBranches(id);
        }

        public ICollection<Location> GetLocations(int id)
        {
            return _assetEntryRepository.GetLocations(id);
        }

        public ICollection<AssetGroup> GetAssetGroups(int id)
        {
            return _assetEntryRepository.GetAssetGroups(id);
        }

        public ICollection<Manufacturer> GetManufacturers(int id)
        {
            return _assetEntryRepository.GetManufacturers(id);
        }

        public ICollection<AssetModel> GetAssetModels(int id)
        {
            return _assetEntryRepository.GetModels(id);
        }




        //Report
        public ICollection<SP_AssetList> GetAssetListReport(string name)
        {
            return _assetEntryRepository.GetAssetListReport(name);
        }
    }
}
