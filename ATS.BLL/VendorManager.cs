using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Models;
using ATS.Repository;
using ATS.Models.Interfaces;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Vendor;

namespace ATS.BLL
{
    public class VendorManager: CommonManager<Vendor>, IVendorManager
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorManager() : base(new VendorRepository())
        {
            _vendorRepository=base._repository as IVendorRepository;
            //_vendorRepository = (IVendorRepository) _repository;
        }


        public override Vendor GetById(int id)
        {
            if (id > 0)
            {
                //return _vendorRepository.GetById(id);
                return base.GetById(id);
            }
            else
            {
                return null;
            }
        }

        public Vendor IsVendorNameExist(string name)
        {
            return _vendorRepository.IsVendorNameExist(name);
        }

        public List<Vendor> Search(VendorSearchVm model)
        {
            return _vendorRepository.Search(model);
        }

    }
}
