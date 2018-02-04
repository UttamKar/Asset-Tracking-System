using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATS.Models.Models.EntityModel
{
    public class Branch: Common
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string ShortName { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}