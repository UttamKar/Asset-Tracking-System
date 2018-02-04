using System.Collections.Generic;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Employee;

namespace ATS.Models.Interfaces.Repository
{
    public interface IEmployeeRepository: ICommonRepository<Employee>
    {
        ICollection<Branch> GetBranches(int id);
        List<Employee> Search(EmployeeSearchVm model);
        Employee IsContactNumberExist(string input);
    }
}
