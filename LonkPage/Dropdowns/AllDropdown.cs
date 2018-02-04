using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;

namespace LonkPage.Dropdowns
{
    public class AllDropdown
    {
        private readonly IOrganizationManager _organizationManager = new OrganizationManager();
        private readonly IBranchManager _branchManager = new BranchManager();
        private readonly IAssetTypeManager _assetTypeManager = new AssetTypeManager();
        private readonly IAssetGroupManager _assetGroupManager = new AssetGroupManager();
        private readonly IManufacturerManager _manufacturerManager = new ManufacturerManager();
        private readonly ILocationManager _locationManager = new LocationManager();
        private readonly IAssetModelManager _assetModelManager = new AssetModelManager();
        private readonly IAssetEntryManager _assetEntryManager = new AssetEntryManager();
        private readonly IEmployeeManager _employeeManager = new EmployeeManager();
        private readonly IVendorManager _vendorManager = new VendorManager();




        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = "---Select---"},
            };
            return items;
        }

        public List<SelectListItem> GetOrganizations()
        {
            var organizationManager = _organizationManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(organizationManager.Select(org => new SelectListItem()
            {
                Value = org.Id.ToString(),
                Text = org.Name
            }));
            return items;
        }

        public List<SelectListItem> GetBranches()
        {
            var branchManager = _branchManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(branchManager.Select(branch => new SelectListItem()
            {
                Value = branch.Id.ToString(),
                Text = branch.Name
            }));
            return items;
        }


        public List<SelectListItem> GetAssetTypes()
        {
            var assetTypeManager = _assetTypeManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(assetTypeManager.Select(assetType => new SelectListItem()
            {
                Value = assetType.Id.ToString(),
                Text = assetType.Name
            }));
            return items;
        }

        public List<SelectListItem> GetAssetGroups()
        {
            var assetGroupManager = _assetGroupManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(assetGroupManager.Select(assetGroup => new SelectListItem()
            {
                Value = assetGroup.Id.ToString(),
                Text = assetGroup.Name
            }));
            return items;
        }


        public List<SelectListItem> GetManufacturers()
        {
            var manufacturerManager = _manufacturerManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(manufacturerManager.Select(manufacturer => new SelectListItem()
            {
                Value = manufacturer.Id.ToString(),
                Text = manufacturer.Name
            }));
            return items;
        }

        public List<SelectListItem> GetLocations()
        {
            var locationManager = _locationManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(locationManager.Select(location => new SelectListItem()
            {
                Value = location.Id.ToString(),
                Text = location.Name
            }));
            return items;
        }

        public List<SelectListItem> GetAssetModels()
        {
            var assetModelManager = _assetModelManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(assetModelManager.Select(model => new SelectListItem()
            {
                Value = model.Id.ToString(),
                Text = model.Name
            }));
            return items;
        }

        public List<SelectListItem> GetEmployees()
        {
            var employees = _employeeManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(employees.Select(emp => new SelectListItem()
            {
                Value = emp.Id.ToString(),
                Text = emp.FirstName+" "+emp.LastName
            }));
            return items;
        }

        public List<SelectListItem> GetAssetEntries()
        {
            var assetEntryManager = _assetEntryManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(assetEntryManager.Select(assetEntry => new SelectListItem()
            {
                Value = assetEntry.Id.ToString(),
                Text = assetEntry.DescriptionName
            }));
            return items;
        }

        public List<SelectListItem> GetAssetsForCheckOut()
        {
            var assetEntryManager = _assetEntryManager.GetAll();
            //To Load all assets except checkout
            var selectedAsset = assetEntryManager.Where(c => c.Status != "3");
            var items = GetDefaultSelectListItem();
            items.AddRange(selectedAsset.Select(assetEntry => new SelectListItem()
            {
                Value = assetEntry.Id.ToString(),
                Text = assetEntry.DescriptionName
            }));
            return items;
        }




        public List<SelectListItem> GetVendors()
        {
            var vendors = _vendorManager.GetAll();
            var items = GetDefaultSelectListItem();
            items.AddRange(vendors.Select(v => new SelectListItem()
            {
                Value = v.Id.ToString(),
                Text = v.Name
            }));
            return items;
        }
    }
}