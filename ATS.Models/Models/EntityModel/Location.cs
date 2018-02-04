using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATS.Models.Models.EntityModel
{
    public class Location: Common
    {
        //public int Id { get; set; }
        //[DisplayName("Location Name")]
        //public string Name { get; set; }
        //[DisplayName("Short Name")]
        //public string ShortName { get; set; }
        //[DisplayName("Branch Name")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [DisplayName("Organization Name")]
        public int OrganizationId { get; set; }

        public ICollection<AssetEntry> AssetEntries { get; set; }
    }
}
