using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Vendor;

namespace ATS.Models.Interfaces.BLL
{
    public interface IVendorManager: ICommonManager<Vendor>
    {
        Vendor IsVendorNameExist(string name);
        List<Vendor> Search(VendorSearchVm model);
    }
}
