using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.Audit
{
    public class AuditCreateVm
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




        public string AssetNo { get; set; }
        public string Name { get; set; }
        public string EmployeeName { get; set; }

    }
}
