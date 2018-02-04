using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ATS.Models.DatabaseContext;
using ATS.Models.Models.EntityModel;

namespace ATS.Models.Models.ViewModel.Branch
{
    public class BranchCreateVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Branch Name")]
        [StringLength(100, ErrorMessage = "Maximun length is 100 characters")]
        [Index(IsUnique = true)]
        [DisplayName("Branch Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Short Name not Generated")]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }


        [Required(ErrorMessage = "Select Organization Name")]
        public int OrganizationId { get; set; }
        public virtual EntityModel.Organization Organization { get; set; }
        public virtual ICollection<EntityModel.Employee> Employees { get; set; }


        public List<SelectListItem> OrganizationLookUp { get; set; }

    }
}
