using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Repository;

namespace ATS.BLL
{
    public class BranchManager: CommonManager<Branch>, IBranchManager
    {
        private IBranchRepository _branchRepository;

        public BranchManager() : base(new BranchRepository())
        {
            _branchRepository = base._repository as IBranchRepository;
            //_branchRepository = (IBranchRepository) _repository;
        }

        //public IBranchRepository _branchRepository
        //{
        //    get
        //    {
        //        return (IBranchRepository)_repository;
        //        //return base._repository as IBranchRepository;
        //    }
        //}
        //public BranchManager() : base(new BranchRepository())
        //{  
        //}


        public override Branch GetById(int id)
        {
            if (id > 0)
            {
                //return _branchRepository.GetById(id);
                return base.GetById(id);
            }
            else
            {
                return null;
            }
            
        }

        public bool IsBranchNameExist(string name, int orgId)
        {
            var result =
                _branchRepository.Get(c => c.Name.Contains(name) && c.OrganizationId.Equals(orgId)).SingleOrDefault();
            return result != null;
        }


    }
}
