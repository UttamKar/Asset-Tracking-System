using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.ViewModel.SP
{
    public class SP_AssetList
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string AssetBrand { get; set; }
        public string SerialNo { get; set; }
        public int? OrganizationId { get; set; }
        public int? BranchId { get; set; }
        public string LocationName { get; set; }
        public string LocationShortName { get; set; }
        public string Status { get; set; }
    }
}
