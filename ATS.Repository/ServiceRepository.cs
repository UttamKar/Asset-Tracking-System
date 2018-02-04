using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class ServiceRepository: CommonRepository<Service>, IServiceRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public ServiceRepository() : base(new ATSDBContext())
        {
        }

        public List<Service> GetServiceDetails(int id)
        {
            return Context.Services.Where(c => c.AssetEntryId == id).ToList();
        }
    }
}
