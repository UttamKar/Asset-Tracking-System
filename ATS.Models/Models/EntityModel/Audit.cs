using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel
{
    public class Audit
    {
        public int Id { get; set; }
        public bool AssetOk { get; set; }
        public bool AssetOnLocation { get; set; }
        public bool AssetUnderCustodian { get; set; }
        public string Comment { get; set; }
        public DateTime AuditDate { get; set; }
        public int AssetEntryId { get; set; }
        public int LocationId { get; set; }
    }
}
