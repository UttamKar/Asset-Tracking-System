using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel.Partial
{
    public class Note
    {
        public int Id { get; set; }
        public string AssetEntryNotes { get; set; }
        public virtual AssetEntry AssetEntry { get; set; }
        public int AssetEntryId { get; set; }
    }
}
