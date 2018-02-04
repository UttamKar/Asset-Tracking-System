using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATS.Models.Models.EntityModel
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [DisplayName("Contact")]
        public string ContactNo { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        [DisplayName("Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public int OrganizationId { get; set; }

        public ICollection<CheckOut> CheckOuts { get; set; }
    }
}