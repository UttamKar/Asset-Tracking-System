using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Migrations;
using ATS.Repository;

namespace ATS.BLL
{
    public class CheckOutAssetListManager: CommonManager<CheckOutAssetList>, ICheckOutAssetListManager
    {
        private readonly ICheckOutAssitListRepository _checkOutAssitListRepository;
        public CheckOutAssetListManager() : base(new CheckOutAssitListRepository())
        {
            _checkOutAssitListRepository=base._repository as ICheckOutAssitListRepository;
        }
    }
}
