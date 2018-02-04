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
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class LocationRepository: CommonRepository<Location>, ILocationRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public LocationRepository() : base(new ATSDBContext())
        {
        }

 //For cascading Dropdown
        public ICollection<Branch> GetBranches(int id)
        {
            return Context.Branches.Where(c => c.OrganizationId == id).OrderBy(c => c.Name).ToList();
        }
    }
}
