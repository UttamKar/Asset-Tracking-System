using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel
{
    public class CheckOutAssetList
    {
        public int Id { get; set; }
        public string AssetNo { get; set; }
        public string Name { get; set; }
        public virtual CheckOut CheckOut { get; set; }
        public int CheckOutId { get; set; }
        public int AssetEntryId { get; set; }
        public ICollection<CheckIn> CheckIns { get; set; }
    }
}
