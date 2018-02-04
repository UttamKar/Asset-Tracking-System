using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Manufacturer;

namespace ATS.Models.Interfaces.BLL
{
    public interface IManufacturerManager: ICommonManager<Manufacturer>
    {
        List<Manufacturer> Search(ManufacturerSearchVm model);
        bool IsManufacturerNameExist(string input);
    }
}
