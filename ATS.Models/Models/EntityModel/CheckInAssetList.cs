using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel
{
    public class CheckInAssetList
    {
        public int Id { get; set; }
        public string AssetNo { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        public virtual CheckIn CheckIn { get; set; }
        public int CheckInId { get; set; }
        public int AssetEntryId { get; set; }
    }
}
