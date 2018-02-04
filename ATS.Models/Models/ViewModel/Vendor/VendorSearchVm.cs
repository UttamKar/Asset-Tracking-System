using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ATS.Models.Models.ViewModel.Vendor
{
    public class VendorSearchVm
    {
      public string Name { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public List<EntityModel.Vendor> Vendors { get; set; }
    }
}
