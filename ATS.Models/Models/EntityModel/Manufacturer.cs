using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATS.Models.Models.EntityModel
{
    public class Manufacturer: Common
    {
        //public int Id { get; set; }
        //[DisplayName("Manufacturer Name")]
        //public string Name { get; set; }
        //[DisplayName("Short Name")]
        //public string ShortName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        [DisplayName("Asset Group")]
        public int AssetGroupId { get; set; }
        public virtual AssetGroup AssetGroup { get; set; }
    }
}
