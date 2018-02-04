using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class OrganizationRepository : CommonRepository<Organization>, IOrganizationRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }

        public OrganizationRepository() : base(new ATSDBContext())
        {
        }

        public Organization IsOrganizationNameExist(string name)
        {
            var x= Context.Organizations.FirstOrDefault(c => c.Name.Equals(name));
            return x;
        }
    }
}
