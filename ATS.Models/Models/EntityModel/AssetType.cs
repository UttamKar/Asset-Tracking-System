using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATS.Models.Models.EntityModel
{
    public class AssetType: Common
    {
        //public int Id { get; set; }
        //[DisplayName("Asset Type Name")]
        //public string Name { get; set; }
        //[DisplayName("Short Name")]
        //public string ShortName { get; set; }
        public string Code { get; set; }
        public virtual ICollection<AssetGroup> AssetGroups { get; set; }
    }
}
