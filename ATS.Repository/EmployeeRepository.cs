using ATS.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Employee;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class EmployeeRepository : CommonRepository<Employee>, IEmployeeRepository
    {
        public ATSDBContext Context
            {
                get { return (ATSDBContext)db;}
            }
        public EmployeeRepository() : base(new ATSDBContext())
        {
        }

//For cascading Dropdown
        public ICollection<Branch> GetBranches(int id)
        {
            return Context.Branches.Where(c => c.OrganizationId == id).OrderBy(c => c.Name).ToList();
        }

        public List<Employee> Search(EmployeeSearchVm model)
        {
            var employees = Context.Employees.AsQueryable();
            if (model.OrganizationId != null)
            {
                employees = employees.Where(c => c.OrganizationId == model.OrganizationId);
            }
            if (model.BranchId != null)
            {
                employees = employees.Where(c => c.BranchId == model.BranchId);
            }
            if (!string.IsNullOrEmpty(model.FirstName))
            {
                employees = employees.Where(c => c.FirstName.ToLower().Contains(model.FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.LastName))
            {
                employees = employees.Where(c => c.LastName.ToLower().Contains(model.LastName.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                employees = employees.Where(c => c.Email.ToLower().Contains(model.Email.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.ContactNo))
            {
                employees = employees.Where(c => c.ContactNo.ToLower().Contains(model.ContactNo.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.Code))
            {
                employees = employees.Where(c => c.Code.ToLower().Contains(model.Code.ToLower()));
            }
            return employees.ToList();
        }

        public Employee IsContactNumberExist(string input)
        {
            return Context.Employees.FirstOrDefault(c => c.ContactNo.Equals(input));
        }

    }
}
