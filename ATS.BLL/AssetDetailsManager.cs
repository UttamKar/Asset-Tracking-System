using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Migrations;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Repository;

namespace ATS.BLL
{
    public class AssetDetailsManager: CommonManager<assetDetails>, IAssetDetailsManager
    {
        private readonly IAssetDetailsRepository _assetDetailsRepository;
        public AssetDetailsManager() : base(new AssetDetailsRepository())
        {
            _assetDetailsRepository=base._repository as IAssetDetailsRepository;
        }

        public IEnumerable<AssetDetails> GetAllAssetDetails(int id)
        {
            return _assetDetailsRepository.GetAllAssetDetails(id);
        }
    }
}
