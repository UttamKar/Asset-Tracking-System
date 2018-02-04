using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class CheckInAssetListRepository: CommonRepository<CheckInAssetList>, ICheckInAssetListRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public CheckInAssetListRepository() : base(new ATSDBContext())
        {
        }

        public CheckInAssetList GetAssetByAssetId(int assetId)
        {
            return Context.CheckInAssetLists.FirstOrDefault(c => c.AssetEntryId == assetId);
        }
    }
}
