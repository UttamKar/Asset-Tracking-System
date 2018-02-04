using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.Repository;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.CheckIn;
using ATS.Repository.Common;

namespace ATS.Repository
{
    public class CheckInRepository:CommonRepository<CheckIn>, ICheckInRepository
    {
        public ATSDBContext Context
        {
            get { return (ATSDBContext)db; }
        }

        public CheckInRepository() : base(new ATSDBContext())
        {
        }


        //To get all assigned Assets to an Employee by Employee Id
        public List<CheckInCreateVm> SearchAssetForCheckIn(int id)
        {
                var result = (from checkOutAssetList in Context.CheckOutAssetLists
                              join checkOut in Context.CheckOuts on checkOutAssetList.CheckOutId equals checkOut.Id
                              join employee in Context.Employees on checkOut.EmployeeId equals employee.Id
                              where checkOut.EmployeeId == id
                              select
                                  new CheckInCreateVm()
                                  {
                                      Id = checkOutAssetList.Id,
                                      AssetNo = checkOutAssetList.AssetNo,
                                      Name = checkOutAssetList.Name,
                                      DueDate = checkOut.DueDate,
                                      EmployeeId = checkOut.EmployeeId,
                                      EmployeeName = employee.FirstName+" "+ employee.LastName,
                                      AssetEntryId = checkOutAssetList.AssetEntryId
                                  }).ToList();
                return result;
           
        }

        //To get a particular Asset by Asset Id
        public List<CheckInCreateVm> GetAssetById(int id)
        {
            var result = (from checkOutAssetList in Context.CheckOutAssetLists
                          join checkOut in Context.CheckOuts on checkOutAssetList.CheckOutId equals checkOut.Id
                          where checkOutAssetList.AssetEntryId == id
                          select
                              new CheckInCreateVm()
                              {
                                  Id = checkOutAssetList.Id,
                                  AssetNo = checkOutAssetList.AssetNo,
                                  Name = checkOutAssetList.Name,
                                  DueDate = checkOut.DueDate,
                                  EmployeeId = checkOut.EmployeeId,
                                  AssetEntryId = checkOutAssetList.AssetEntryId
                              });
            return result.ToList();
        }

    }
}
