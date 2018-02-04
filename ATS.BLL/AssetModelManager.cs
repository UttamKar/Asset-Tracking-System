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
using ATS.Models.Models.ViewModel.AssetModel;
using ATS.Repository;

namespace ATS.BLL
{
    public class AssetModelManager: CommonManager<AssetModel>, IAssetModelManager
    {
        private IAssetModelRepository _assetModelRepository;
        public AssetModelManager() : base(new AssetModelRepository())
        {
            _assetModelRepository=base._repository as IAssetModelRepository;
        }

        public ICollection<Manufacturer> GetManufacturers(int id)
        {
            return _assetModelRepository.GetManufacturers(id);
        }

        public List<AssetModel> Search(AssetModelSearchVm model)
        {
            return _assetModelRepository.Search(model);
        }
    }
}
