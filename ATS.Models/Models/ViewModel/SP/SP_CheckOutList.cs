using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.ViewModel.SP
{
    public class SP_CheckOutList
    {
        public int Id { get; set; }
        public string AssetNo { get; set; }
        public string AssetName { get; set; }
        public int? CheckOutId { get; set; }
        public string EmployeeNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
        public int? EmployeeId { get; set; }
        public virtual EntityModel.Employee Employee { get; set; }
    }
}
