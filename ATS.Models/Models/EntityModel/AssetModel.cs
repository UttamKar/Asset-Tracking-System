using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ATS.Models.Models.EntityModel
{
    public class AssetModel: Common
    {
        //public int Id { get; set; }
        //[DisplayName("Asset Model")]
        //public string Name { get; set; }
        //[DisplayName("Short Name")]
        //public string ShortName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        [DisplayName("Manufacturer Name")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [DisplayName("Asset Group")]
        public int AssetGroupId { get; set; }

       
    }
}
