using System;
using System.ComponentModel.DataAnnotations;

namespace ATS.Models.Models.EntityModel.Partial
{
    public class AssetDetails
    {
        public int Id { get; set; }
        public string SerialNo { get; set; }
        public string DescriptionName { get; set; }
        public string EntryDate { get; set; }
        public string Status { get; set; }
        public int? AssetEntryId { get; set; }
        public int? EmployeeId { get; set; }
        //public virtual AssetEntry AssetEntry { get; set; }
    }
}
