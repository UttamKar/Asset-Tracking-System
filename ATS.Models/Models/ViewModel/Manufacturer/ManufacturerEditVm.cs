using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.Manufacturer
{
    public class ManufacturerEditVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Asset Name")]
        [StringLength(50, ErrorMessage = "Maximun length is 50 characters")]
        [Index(IsUnique = true)]
        [DisplayName("Manufacturer")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Code not Generated")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Asset Group")]
        public int AssetGroupId { get; set; }
        public virtual EntityModel.AssetGroup AssetGroup { get; set; }

        public List<SelectListItem> AssetGroupLookUp { get; set; }
    }
}
