using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Vendor;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class VendorRepository: CommonRepository<Vendor>, IVendorRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext) db; }
        }

        public VendorRepository() : base(new ATSDBContext())
        {
        }

        public Vendor IsVendorNameExist(string name)
        {
            return Context.Vendors.FirstOrDefault(c => c.Name.Equals(name));
        }

        public List<Vendor> Search(VendorSearchVm model)
        {
            var vendors = Context.Vendors.AsQueryable();
            if (!string.IsNullOrEmpty(model.Name))
            {
                vendors = vendors.Where(c => c.Name.ToLower().Contains(model.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.ShortName))
            {
                vendors = vendors.Where(c => c.ShortName.ToLower().Contains(model.ShortName.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                vendors = vendors.Where(c => c.Email.ToLower().Contains(model.Email.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.ContactNo))
            {
                vendors = vendors.Where(c => c.ContactNo.ToLower().Contains(model.ContactNo.ToLower()));
            }
            return vendors.ToList();
        }
    }
}
