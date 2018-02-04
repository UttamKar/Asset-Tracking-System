using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Repository;

namespace ATS.BLL
{
    public class CheckInAssetListManager: CommonManager<CheckInAssetList>, ICheckInAssetListManager
    {
        private ICheckInAssetListRepository _checkInAssetListRepository;
        public CheckInAssetListManager() : base(new CheckInAssetListRepository())
        {
            _checkInAssetListRepository=base._repository as ICheckInAssetListRepository;
        }

        public CheckInAssetList GetAssetByAssetId(int assetId)
        {
            return _checkInAssetListRepository.GetAssetByAssetId(assetId);
        }
    }
}
