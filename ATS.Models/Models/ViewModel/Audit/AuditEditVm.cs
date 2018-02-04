using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.Audit
{
    public class AuditEditVm
    {
        public int Id { get; set; }
        public bool AssetOk { get; set; }
        public bool AssetOnLocation { get; set; }
        public bool AssetUnderCustodian { get; set; }
        public string Comment { get; set; }
        public DateTime AuditDate { get; set; }
        public int AssetEntryId { get; set; }
        public int LocationId { get; set; }
        public List<SelectListItem> LocationLookUp { get; set; }
    }
}
