using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel.Partial
{
    public class Service
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ServiceingCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ServiceDate { get; set; }
        public string PartsCost { get; set; }
        public string ServiceBy { get; set; }
        public string Tax { get; set; }
        public virtual AssetEntry AssetEntry { get; set; }
        public int AssetEntryId { get; set; }

    }
}
