using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.EntityModel.Partial
{
    public class Attachment
    {
        public int Id { get; set; }
        public string File { get; set; }
        public virtual AssetEntry AssetEntry { get; set; }
        public int AssetEntryId { get; set; }
    }
}
