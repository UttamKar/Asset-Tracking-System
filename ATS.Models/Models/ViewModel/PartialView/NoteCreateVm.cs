using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Models.ViewModel.PartialView
{
    public class NoteCreateVm
    {
        public int Id { get; set; }
        [Required]
        public string AssetEntryNotes { get; set; }
        public virtual EntityModel.AssetEntry AssetEntry { get; set; }
        public int AssetEntryId { get; set; }
    }
}
