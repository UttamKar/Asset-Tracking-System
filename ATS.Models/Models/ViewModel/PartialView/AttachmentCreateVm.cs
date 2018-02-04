using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.ViewModel.PartialView
{
    public class AttachmentCreateVm
    {
        public int Id { get; set; }
        public string File { get; set; }
        public virtual EntityModel.AssetEntry AssetEntry { get; set; }
        public int AssetEntryId { get; set; }
    }
}
