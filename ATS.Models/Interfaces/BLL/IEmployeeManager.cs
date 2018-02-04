using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Employee;

namespace ATS.Models.Interfaces.BLL
{
    public interface IEmployeeManager: ICommonManager<Employee>
    {
        ICollection<Branch> GetBranches(int id);
        List<Employee> Search(EmployeeSearchVm model);
        bool IsContactNumberExist(string input);
    }
}
