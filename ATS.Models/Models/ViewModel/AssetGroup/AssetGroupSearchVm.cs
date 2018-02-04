using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.AssetGroup
{
    public class AssetGroupSearchVm
    {
        [DisplayName("Asset Group Name")]
        public string Name { get; set; }

        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        public string Code { get; set; }

        [DisplayName("Asset Type")]
        public int? AssetTypeId { get; set; }
        public virtual EntityModel.AssetType AssetType { get; set; }

        public List<SelectListItem> AssetTypeLookup { get; set; }
        public List<EntityModel.AssetGroup> AssetGroups { get; set; }
    }
}
