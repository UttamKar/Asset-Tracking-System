using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel
{
    public class CheckIn
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public string SetLocation { get; set; }
        public string CheckInStatus { get; set; }
        //public int AssetEntryId { get; set; }
        public int EmployeeId { get; set; }
        //public int CheckOutAssetListId { get; set; }
        //public virtual CheckOutAssetList CheckOutAssetList { get; set; }

        public ICollection<CheckInAssetList> CheckInAssetLists { get; set; }
    }
}
