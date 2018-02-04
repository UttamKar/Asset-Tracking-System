using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.Employee
{
    public class EmployeeSearchVm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string ContactNo { get; set; }
        public string Code { get; set; }

        public int? BranchId { get; set; }
        public virtual EntityModel.Branch Branch { get; set; }

        public int? OrganizationId { get; set; }

        public List<SelectListItem> OrganizationLookUp { get; set; }
        public List<SelectListItem> BranchLookUp { get; set; }
        public List<EntityModel.Employee> Employees { get; set; }
    }
}
