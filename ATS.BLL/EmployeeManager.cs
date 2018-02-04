using ATS.Models.Interfaces;
using ATS.Models.Models;
using ATS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Common;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Employee;

namespace ATS.BLL
{
    public class EmployeeManager: CommonManager<Employee>, IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager() : base(new EmployeeRepository())
        {
            _employeeRepository=base._repository as IEmployeeRepository;
            //_employeeRepository = (IEmployeeRepository) _repository;
        }

        public override Employee GetById(int id)
        {
            if (id > 0)
            {
                //return _employeeRepository.GetById(id);
                return base.GetById(id);
            }
            else
            {
                return null;
            }
        }

        //for cascading dropdown
        public ICollection<Branch> GetBranches(int id)
        {
            return _employeeRepository.GetBranches(id);
        }

        public List<Employee> Search(EmployeeSearchVm model)
        {
            return _employeeRepository.Search(model);
        }

        public bool IsContactNumberExist(string input)
        {
            var contactNumber = _employeeRepository.IsContactNumberExist(input);
            return contactNumber != null;
        }
        
    }
}
