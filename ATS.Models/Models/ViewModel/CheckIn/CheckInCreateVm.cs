using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Models.ViewModel.CheckIn
{
    public class CheckInCreateVm
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public string SetLocation { get; set; }
        public string CheckInStatus { get; set; }
        public string AssetNo { get; set; }
        public string Name { get; set; }
        public int AssetEntryId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        public string assetIDArr { get; set; }

        public int CheckOutAssetListId { get; set; }
        public virtual CheckOutAssetList CheckOutAssetList { get; set; }

        public List<SelectListItem> EmployeeLookup { get; set; }

        public virtual ICollection<CheckInAssetList> CheckInAssetLists { get; set; }
    }
}
