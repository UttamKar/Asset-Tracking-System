using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.ViewModel.AssetType
{
    public class AssetTypeSearchVm
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        //public virtual ICollection<EntityModel.AssetGroup> AssetGroups { get; set; }
        public List<EntityModel.AssetType> AssetTypes { get; set; }
    }
}
