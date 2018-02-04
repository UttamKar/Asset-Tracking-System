using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATS.Models.Models.EntityModel
{
    public class Vendor: Common
    {
        //public int Id { get; set; }
        //[DisplayName("Vendor Name")]
        //public string Name { get; set; }
        //[DisplayName("Short Name")]
        //public string ShortName { get; set; }
        public string Email { get; set; }

        [DisplayName("Contact")]
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
    }
}