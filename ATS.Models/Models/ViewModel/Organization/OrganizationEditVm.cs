using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ATS.Models.DatabaseContext;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Models.ViewModel.Organization
{
    public class OrganizationEditVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Organization's Name")]
        [StringLength(100, ErrorMessage = "Maximun length is 100 characters")]
        //[Index(IsUnique = true)]
        [DisplayName("Organization Name")]

        public string Name { get; set; }


        [Required(ErrorMessage = "Enter Short Name")]
        [StringLength(10, ErrorMessage = "Maximun length is 10 characters")]
        [RegularExpression(@"^[A-Z]{4,10}$", ErrorMessage = "Only uppercase letters are allowed with no empty space. Range 4-10 character")]
        [DisplayName("Short Name/ Code")]
        public string ShortName { get; set; }


        [Required(ErrorMessage = "Enter Location Details")]
        [DataType(DataType.MultilineText)]
        public string Location { get; set; }

        public virtual ICollection<EntityModel.Branch> Branches { get; set; }


    }
}
