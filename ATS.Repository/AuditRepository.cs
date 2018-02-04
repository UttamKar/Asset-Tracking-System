using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Audit;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class AuditRepository: CommonRepository<Audit>, IAuditRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }
        public AuditRepository() : base(new ATSDBContext())
        {
        }


        public List<AuditCreateVm> SearchAssetByLocationId(int id)
        {
            var result = (from checkOutAssetList in Context.CheckOutAssetLists
                          join checkOut in Context.CheckOuts on checkOutAssetList.CheckOutId equals checkOut.Id
                          join employee in Context.Employees on checkOut.EmployeeId equals employee.Id
                          where checkOut.LocationId == id
                          select
                              new AuditCreateVm()
                              {
                                  Id = checkOutAssetList.Id,
                                  AssetNo = checkOutAssetList.AssetNo,
                                  Name = checkOutAssetList.Name,
                                  EmployeeName = employee.FirstName + " " + employee.LastName,
                                  AssetEntryId = checkOutAssetList.AssetEntryId
                              }).ToList();
            return result;
        }
    }
}
