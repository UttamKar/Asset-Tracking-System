using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATS.Models.Models.EntityModel.Partial;

namespace ATS.Models.Models.EntityModel
{
    public class AssetEntry
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        [DisplayName("Serial No")]
        public string SerialNo { get; set; }
        [DisplayName("Description / Name")]
        public string DescriptionName { get; set; }
        public string Status { get; set; }
        public string Attachment { get; set; }
        [DisplayName("Location")]
        public int LocationId { get; set; }
        [DisplayName("Branch")]
        public int BranchId { get; set; }
        [DisplayName("Organization")]
        public int OrganizationId { get; set; }
        [DisplayName("Serial No")]
        public int AssetModelId { get; set; }
        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }
        [DisplayName("Asset Group")]
        public int AssetGroupId { get; set; }
        [DisplayName("Asset Type")]
        public int AssetTypeId { get; set; }

        public virtual Location Location { get; set; }
        public virtual AssetModel AssetModel { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Finance> Finances { get; set; }

    }
}
