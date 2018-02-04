using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class CascadingDropdownsController : Controller
    {


//Object Declearation
#region
        AllDropdown _dropdown=new AllDropdown();
        readonly IEmployeeManager _employeeManager = new EmployeeManager();
        readonly IAssetEntryManager _assetEntryManager = new AssetEntryManager();
        readonly IAssetTypeManager _assetTypeManager = new AssetTypeManager();
        readonly IAssetGroupManager _assetGroupManager = new AssetGroupManager();
        readonly IManufacturerManager _manufacturerManager = new ManufacturerManager();
        readonly IVendorManager _vendorManager = new VendorManager();
        readonly IOrganizationManager _organizationManager = new OrganizationManager();
        readonly IBranchManager _branchManager = new BranchManager();

#endregion


//Get by Id
 #region
        public JsonResult GetBranches(int id)
        {
            var jsonItems = _employeeManager.GetBranches(id);
            var jsonItem = jsonItems.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Json(jsonItem, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetLocations(int id)
        {
            var jsonItems = _assetEntryManager.GetLocations(id);
            var jsonItem = jsonItems.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Json(jsonItem, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetAssetGroups(int id)
        {
            var jsonItems = _assetEntryManager.GetAssetGroups(id);
            var jsonItem = jsonItems.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Json(jsonItem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetManufacturers(int id)
        {
            var jsonItems = _assetEntryManager.GetManufacturers(id);
            var jsonItem = jsonItems.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Json(jsonItem, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetAssetModels(int id)
        {
            var jsonItems = _assetEntryManager.GetAssetModels(id);
            var jsonItem = jsonItems.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Json(jsonItem, JsonRequestBehavior.AllowGet);
        }



        #endregion



        //Short Name pull from database
        #region
        public JsonResult GetAssetNoById(int id)
        {
            var jsonItems = _assetEntryManager.GetById(id).SerialNo;
            return Json(jsonItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployeeCodeById(int id)
        {
            var jsonItems = _employeeManager.GetById(id).Code;
            return Json(jsonItems, JsonRequestBehavior.AllowGet);
        }

        #endregion


        //Unique Checking
        #region

        //Vendor Name Existence Checking
        public string IsVendorNameExist(string input)
        {
            var vendorName = _vendorManager.IsVendorNameExist(input);

            if (vendorName != null)
            {
                return "Available";
            }

            return "";
        }


        //Organization Name Existence Checking
        public string IsOrganizationNameExist(string input)
        {
            var organizationName = _organizationManager.IsOrganizationNameExist(input);

            if (organizationName != null)
            {
                return "Available";
            }

            return "";
        }


        //Branch Name Existence Checking
        public string IsBranchNameExist(string name, int orgId)
        {
            bool branchName = _branchManager.IsBranchNameExist(name, orgId);

            if (branchName == true)
            {
                return "Available";
            }

            return "";
        }


        //Asset Type name existence checking
        public string IsAssetTypeNameExist(string input)
        {
            bool assetTypeName = _assetTypeManager.IsAssetTypeNameExist(input);

            if (assetTypeName == true)
            {
                return "Available";
            }

            return "";
        }


        //Asset Group name existence checking
        public string IsAssetGroupNameExist(string input)
        {
            bool assetGroupName = _assetGroupManager.IsAssetGroupNameExist(input);

            if (assetGroupName == true)
            {
                return "Available";
            }

            return "";
        }


        //Asset Group name existence checking
        public string IsManufacturerNameExist(string input)
        {
            bool assetManufacturerName = _manufacturerManager.IsManufacturerNameExist(input);

            if (assetManufacturerName == true)
            {
                return "Available";
            }

            return "";
        }


        //Contact number existence checking for Employee Setup
        public string IsContactNumberExist(string input)
        {
            bool assetManufacturerName = _employeeManager.IsContactNumberExist(input);

            if (assetManufacturerName == true)
            {
                return "Available";
            }
            return "";
        }


#endregion



    }
 }