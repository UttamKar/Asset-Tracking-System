using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Migrations;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class AssetDetailsRepository: CommonRepository<assetDetails>, IAssetDetailsRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public AssetDetailsRepository() : base(new ATSDBContext())
        {
        }

        public IEnumerable<AssetDetails> GetAllAssetDetails(int id)
        {
            return Context.AssetDetailses.Where(c => c.AssetEntryId == id);
        }
    }
}
