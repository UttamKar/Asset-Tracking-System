using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Models.ViewModel.CheckOut
{
    public class CheckOutEditVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select Employee Name")]
        public string EmployeeNo { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "Please select Due Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Please select Employee Type")]
        public string CheckOutFor { get; set; }
        public string Comments { get; set; }
        [Required(ErrorMessage = "Please select Employee Name")]
        public int EmployeeId { get; set; }
        public virtual EntityModel.Employee Employee { get; set; }
        [Required(ErrorMessage = "Please select Location")]
        public int LocationId { get; set; }
        public string AssetNo { get; set; }
        public string AssetName { get; set; }

        [Required(ErrorMessage = "Please select Asset Name")]
        public int AssetEntryId { get; set; }


        public ICollection<CheckOutAssetList> CheckOutAssetLists { get; set; }


        public List<SelectListItem> LocationLookUp { get; set; }
        public List<SelectListItem> EmployeeLookUp { get; set; }
        public List<SelectListItem> AssetEntryLookUp { get; set; }
    }
}
