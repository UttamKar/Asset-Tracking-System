using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Manufacturer;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class ManufacturerRepository: CommonRepository<Manufacturer>, IManufacturerRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public ManufacturerRepository() : base(new ATSDBContext())
        {
        }

        public List<Manufacturer> Search(ManufacturerSearchVm model)
        {
            var manufacturers = Context.Manufacturers.AsQueryable();
            if (model.AssetGroupId != null)
            {
                manufacturers = manufacturers.Where(c => c.AssetGroupId == model.AssetGroupId);
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                manufacturers = manufacturers.Where(c => c.Name.ToLower().Contains(model.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.ShortName))
            {
                manufacturers = manufacturers.Where(c => c.ShortName.ToLower().Contains(model.ShortName.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.Code))
            {
                manufacturers = manufacturers.Where(c => c.Code.ToLower().Contains(model.Code.ToLower()));
            }
            return manufacturers.ToList();
        }

        public Manufacturer IsManufacturerNameExist(string input)
        {
            return Context.Manufacturers.FirstOrDefault(c => c.Name.Equals(input));
        }
    }
}
