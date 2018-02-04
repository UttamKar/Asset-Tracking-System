using System.Collections.Generic;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Vendor;

namespace ATS.Models.Interfaces.Repository
{
    public interface IVendorRepository: ICommonRepository<Vendor>
    {
        Vendor IsVendorNameExist(string name);
        List<Vendor> Search(VendorSearchVm model);
    }
}
