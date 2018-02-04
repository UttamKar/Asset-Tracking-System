using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Models.ViewModel.AssetType
{
    public class AssetTypeEditVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Asset Name")]
        [StringLength(50, ErrorMessage = "Maximun length is 50 characters")]
        [Index(IsUnique = true)]
        [DisplayName("Asset Type Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Enter Short Name")]
        [StringLength(5, ErrorMessage = "Input must be 5 Uppercase Characters")]
        [RegularExpression(@"^[A-Z]{4,10}$", ErrorMessage = "Only 5 uppercase Characters are allowed with no empty space.")]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Enter Code")]
        public string Code { get; set; }



        public virtual ICollection<EntityModel.AssetGroup> AssetGroups { get; set; }
    }
}
