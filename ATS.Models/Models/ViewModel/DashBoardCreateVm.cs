using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.ViewModel
{
    public class DashBoardCreateVm
    {
        public int Id { get; set; }
        public int OrgCount { get; set; }
        public string LastRegisteredOrg { get; set; }
        public int EmpCount { get; set; }
        public string LastRegisteredEmp { get; set; }
        public int VendorCount { get; set; }
        public string LastRegisteredVendor { get; set; }
        public int AssetCount { get; set; }
        public int NewAssetCount { get; set; }
        public int CheckedInCount { get; set; }
        public int CheckedOutCount { get; set; }
    }
}
