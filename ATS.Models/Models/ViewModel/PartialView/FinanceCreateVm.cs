using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.PartialView
{
    public class FinanceCreateVm
    {
        public int Id { get; set; }
        [Required]
        public string PurchasePrice { get; set; }
        public string PONo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public int VendorId { get; set; }
        public virtual EntityModel.AssetEntry AssetEntry { get; set; }
        [Required]
        public int AssetEntryId { get; set; }
        public List<SelectListItem> VendorLookUp { get; set; }
    }
}
