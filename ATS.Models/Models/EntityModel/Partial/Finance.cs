using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.EntityModel.Partial
{
    public class Finance
    {
        public int Id { get; set; }
        public string PurchasePrice { get; set; }
        public string PONo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public int VendorId { get; set; }
        public virtual AssetEntry AssetEntry { get; set; }
        public int AssetEntryId { get; set; }

    }
}
