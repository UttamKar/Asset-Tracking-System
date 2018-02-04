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

namespace ATS.BLL
{
    public class OrganizationManager:CommonManager<Organization>, IOrganizationManager
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationManager() : base(new OrganizationRepository())
        {
            _organizationRepository = base._repository as IOrganizationRepository;
            //_organizationRepository = (IOrganizationRepository) _repository;
        }
        //public IOrganizationRepository _organizationRepository
        //{
        //    get { return (IOrganizationRepository)_repository; }
        //    //get { return base._repository as IOrganizationRepository; }
        //}
        //public OrganizationManager() : base(new OrganizationRepository())
        //{
        //}



        public override Organization GetById(int id)
        {
            if (id > 0)
            {
                //return _organizationRepository.GetById(id);
                return base.GetById(id);
            }
            else
            {
                return null;
            }

        }



        public Organization IsOrganizationNameExist(string name)
        {
            return _organizationRepository.IsOrganizationNameExist(name);
        }
    }
}
