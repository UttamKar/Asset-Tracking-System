using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ATS.Models.Models.EntityModel.Partial;

namespace ATS.Models.Models.ViewModel.AssetEntry
{
    public class AssetEntryCreatVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Brand")]
        public string Brand { get; set; }

        [DisplayName("Serial No")]
        [Required(ErrorMessage = "Serial No not Generated")]
        public string SerialNo { get; set; }

        [DisplayName("Description / Name")]
        [Required(ErrorMessage = "Enter Description")]
        public string DescriptionName { get; set; }

        [Required(ErrorMessage = "Enter Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please attach related Document")]
        public string Attachment { get; set; }

        [DisplayName("Location")]
        [Required(ErrorMessage = "Select Location")]
        public int LocationId { get; set; }

        [DisplayName("Branch")]
        [Required(ErrorMessage = "Select Branch Name")]
        public int BranchId { get; set; }

        [DisplayName("Organization")]
        [Required(ErrorMessage = "Select Organization Name")]
        public int OrganizationId { get; set; }

        [DisplayName("Asset Model")]
        [Required(ErrorMessage = "Select Asset Model")]
        public int AssetModelId { get; set; }

        [DisplayName("Manufacturer")]
        [Required(ErrorMessage = "Select Manufacturer Name")]
        public int ManufacturerId { get; set; }

        [DisplayName("Asset Group")]
        [Required(ErrorMessage = "Select Asset Group")]
        public int AssetGroupId { get; set; }

        [DisplayName("Asset Type")]
        [Required(ErrorMessage = "Select Asset Type")]
        public int AssetTypeId { get; set; }

        public virtual EntityModel.Location Location { get; set; }
        public virtual EntityModel.AssetModel AssetModel { get; set; }

        public List<SelectListItem> OrganizationLookUp { get; set; }
        public List<SelectListItem> BranchLookUp { get; set; }
        public List<SelectListItem> LocationLookUp { get; set; }
        public List<SelectListItem> AssetTypeLookUp { get; set; }
        public List<SelectListItem> AssetGroupLookUp { get; set; }
        public List<SelectListItem> ManufacturerLookUp { get; set; }
        public List<SelectListItem> AssetModelLookUp { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
