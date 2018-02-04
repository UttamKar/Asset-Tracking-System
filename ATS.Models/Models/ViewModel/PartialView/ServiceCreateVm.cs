using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models.EntityModel.Partial;

namespace ATS.Models.Models.ViewModel.PartialView
{
    public class ServiceCreateVm
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ServiceingCost { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ServiceDate { get; set; }
        [Required]
        public string PartsCost { get; set; }
        [Required]
        public string ServiceBy { get; set; }
        [Required]
        public string Tax { get; set; }
        public virtual EntityModel.AssetEntry AssetEntry { get; set; }
        public int AssetEntryId { get; set; }

        public List<Service> Services { get; set; }
    }
}
