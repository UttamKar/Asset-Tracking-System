using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.AssetModel
{
    public class AssetModelSearchVm
    {
        [DisplayName("Asset Model")]
        public string Name { get; set; }

        [DisplayName("Short Name")]
        public string ShortName { get; set; }
        public string Code { get; set; }

        [DisplayName("Manufacturer")]
        public int? ManufacturerId { get; set; }
        public virtual EntityModel.Manufacturer Manufacturer { get; set; }

        [DisplayName("Asset Group")]
        public int? AssetGroupId { get; set; }

        public List<SelectListItem> AssetGroupLookUp { get; set; }
        public List<SelectListItem> ManufacturerLookUp { get; set; }
        public List<EntityModel.AssetModel> AssetModels { get; set; }
    }
}
