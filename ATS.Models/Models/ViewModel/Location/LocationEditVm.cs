using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.Location
{
    public class LocationEditVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Organization's Name")]
        [StringLength(100, ErrorMessage = "Maximun length is 100 characters")]
        [Index(IsUnique = true)]
        [DisplayName("Location")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Short Name Not Generated")]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }


        [Required(ErrorMessage = "Select Branch")]
        [DisplayName("Branch")]
        public int BranchId { get; set; }
        public virtual EntityModel.Branch Branch { get; set; }

        [Required(ErrorMessage = "Select Organization")]
        [DisplayName("Organization")]
        public int OrganizationId { get; set; }


        public List<SelectListItem> OrganizationLookUp { get; set; }
        public List<SelectListItem> BranchLookUp { get; set; }

        public ICollection<EntityModel.AssetEntry> AssetEntries { get; set; }
    }
}
