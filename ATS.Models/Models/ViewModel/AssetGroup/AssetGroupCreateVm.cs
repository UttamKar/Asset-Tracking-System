using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Models.ViewModel.AssetGroup
{
    public class AssetGroupCreateVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Asset Name")]
        [StringLength(50, ErrorMessage = "Maximun length is 50 characters")]
        [Index(IsUnique = true)]
        [DisplayName("Asset Group Name")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Code not Generated")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Select Asset Group")]
        [DisplayName("Asset Type")]
        public int AssetTypeId { get; set; }
        public virtual EntityModel.AssetType AssetType { get; set; }

        public virtual ICollection<EntityModel.Manufacturer> Manufacturers { get; set; }

        public List<SelectListItem> AssetTypeLookup { get; set; }
    }
}
