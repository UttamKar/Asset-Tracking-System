using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.AssetType;
using ATS.Repository;

namespace ATS.BLL
{
    public class AssetTypeManager: CommonManager<AssetType>, IAssetTypeManager
    {
        private IAssetTypeRepository _assetTypeRepository;
        public AssetTypeManager() : base(new AssetTypeRepository())
        {
            _assetTypeRepository = base._repository as IAssetTypeRepository;
        }

        public List<AssetType> Search(AssetTypeSearchVm model)
        {
            return _assetTypeRepository.Search(model);
        }

        public bool IsAssetTypeNameExist(string input)
        {
            var assetTyptName = _assetTypeRepository.IsAssetTypeNameExist(input);
            return assetTyptName != null;
        }
    }
}
