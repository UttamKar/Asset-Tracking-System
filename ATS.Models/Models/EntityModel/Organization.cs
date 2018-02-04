using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATS.Models.Models.EntityModel
{
    public class Organization: Common
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //[DisplayName("Short Name/ Code")]
        //public string ShortName { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}