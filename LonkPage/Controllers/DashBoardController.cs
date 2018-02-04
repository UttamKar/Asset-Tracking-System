using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Models.ViewModel;

namespace LonkPage.Controllers
{
    public class DashBoardController : Controller
    {
        readonly IEmployeeManager _employeeManager=new EmployeeManager();
        readonly IOrganizationManager _organizationManager=new OrganizationManager();
        readonly IAssetEntryManager _assetEntryManager=new AssetEntryManager();
        readonly IVendorManager _vendorManager=new VendorManager();
        // GET: DashBoard
        public ActionResult Create()
        {
            var model=new DashBoardCreateVm()
            {
                EmpCount = _employeeManager.GetAll().Count,
                //LastRegisteredEmp= _employeeManager.GetAll().OrderByDescending(s => s.Id).Take(1).Select(x => x.FirstName).FirstOrDefault(),
                LastRegisteredEmp = _employeeManager.GetAll().OrderByDescending(s => s.Id).Take(1).Select(c =>  c.FirstName + " " + c.LastName ).FirstOrDefault(),

                OrgCount = _organizationManager.GetAll().Count,
                LastRegisteredOrg = _organizationManager.GetAll().OrderByDescending(s => s.Id).Take(1).Select(c => c.Name).FirstOrDefault(),

                AssetCount = _assetEntryManager.GetAll().Count,
                NewAssetCount= _assetEntryManager.GetAll().Count(c => c.Status.Equals("1")),
                CheckedInCount = _assetEntryManager.GetAll().Count(c => c.Status.Equals("2")),
                CheckedOutCount = _assetEntryManager.GetAll().Count(c => c.Status.Equals("3")),

                VendorCount = _vendorManager.GetAll().Count,
                LastRegisteredVendor = _vendorManager.GetAll().OrderByDescending(s => s.Id).Take(1).Select(c => c.Name).FirstOrDefault(),
            };
            return View(model);
        }
    }
}