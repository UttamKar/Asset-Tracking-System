using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Manufacturer;

namespace ATS.Models.Interfaces.Repository
{
    public interface IManufacturerRepository: ICommonRepository<Manufacturer>
    {
        List<Manufacturer> Search(ManufacturerSearchVm model);
        Manufacturer IsManufacturerNameExist(string input);
    }
}
