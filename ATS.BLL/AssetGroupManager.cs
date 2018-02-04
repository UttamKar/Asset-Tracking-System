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
using ATS.Models.Models.ViewModel.AssetGroup;
using ATS.Repository;

namespace ATS.BLL
{
    public class AssetGroupManager: CommonManager<AssetGroup>, IAssetGroupManager
    {
        private IAssetGroupRepository _assetGroupRepository;

        public AssetGroupManager() : base(new AssetGroupRepository())
        {
            _assetGroupRepository=base._repository as IAssetGroupRepository;
            //_assetGroupRepository = (IAssetGroupRepository) _repository;
        }



        public List<AssetGroup> Search(AssetGroupSearchVm model)
        {
            return _assetGroupRepository.Search(model);
        }

        public bool IsAssetGroupNameExist(string input)
        {
            var assetGroupName = _assetGroupRepository.IsAssetTypeNameExist(input);
            return assetGroupName != null;
        }
    }
}
