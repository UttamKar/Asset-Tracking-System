using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Interfaces.Repository
{
    public interface ICheckInAssetListRepository: ICommonRepository<CheckInAssetList>
    {
        CheckInAssetList GetAssetByAssetId(int assetId);
    }
}
