using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Manufacturer;
using ATS.Repository;

namespace ATS.BLL
{
    public class ManufacturerManager: CommonManager<Manufacturer>, IManufacturerManager
    {
        private IManufacturerRepository _manufacturerRepository;
        public ManufacturerManager() : base(new ManufacturerRepository())
        {
            _manufacturerRepository=base._repository as IManufacturerRepository;
        }



        public List<Manufacturer> Search(ManufacturerSearchVm model)
        {
            return _manufacturerRepository.Search(model);
        }

        public bool IsManufacturerNameExist(string input)
        {
            var manufacturerName= _manufacturerRepository.IsManufacturerNameExist(input);
            return manufacturerName != null;
        }
    }
}
