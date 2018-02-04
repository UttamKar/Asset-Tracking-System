using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel
{
    public class CheckOut
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        public string CheckOutFor { get; set; }
        public string Comments { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        
        public int LocationId { get; set; }
        public ICollection<CheckOutAssetList> CheckOutAssetLists { get; set; }
    }
}
