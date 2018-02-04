using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.Manufacturer
{
    public class ManufacturerSearchVm
    {
        [DisplayName("Manufacturer")]
        public string Name { get; set; }
        [DisplayName("Short Name")]
        public string ShortName { get; set; }
        public string Code { get; set; }

        [DisplayName("Asset Group")]
        public int? AssetGroupId { get; set; }
        public virtual EntityModel.AssetGroup AssetGroup { get; set; }
        public List<EntityModel.Manufacturer> Manufacturers { get; set; }

        public List<SelectListItem> AssetGroupLookUp { get; set; }
    }
}
