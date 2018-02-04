using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATS.Models.Models.EntityModel
{
    public class AssetGroup: Common
    {
        //public int Id { get; set; }
        //[DisplayName("Asset Group Name")]
        //public string Name { get; set; }
        //[DisplayName("Short Name")]
        //public string ShortName { get; set; }
        public string Code { get; set; }
        [DisplayName("Asset Type")]
        public int AssetTypeId { get; set; }
        public virtual AssetType AssetType { get; set; }

        public virtual ICollection<Manufacturer> Manufacturers { get; set; }
    }
}
