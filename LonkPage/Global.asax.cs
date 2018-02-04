using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Models.Models.ViewModel;
using ATS.Models.Models.ViewModel.AssetEntry;
using ATS.Models.Models.ViewModel.AssetGroup;
using ATS.Models.Models.ViewModel.AssetModel;
using ATS.Models.Models.ViewModel.AssetType;
using ATS.Models.Models.ViewModel.Audit;
using ATS.Models.Models.ViewModel.Branch;
using ATS.Models.Models.ViewModel.CheckIn;
using ATS.Models.Models.ViewModel.CheckOut;
using ATS.Models.Models.ViewModel.Employee;
using ATS.Models.Models.ViewModel.Location;
using ATS.Models.Models.ViewModel.Manufacturer;
using ATS.Models.Models.ViewModel.Organization;
using ATS.Models.Models.ViewModel.PartialView;
using ATS.Models.Models.ViewModel.Vendor;

namespace LonkPage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<OrganizationCreateVm, Organization>();
                config.CreateMap<Organization, OrganizationEditVm>();
                config.CreateMap<OrganizationEditVm, Organization>();

                config.CreateMap<BranchCreateVm, Branch>();
                config.CreateMap<Branch, BranchEditVm>();
                config.CreateMap<BranchEditVm, Branch>();

                config.CreateMap<VendorCreateVm, Vendor>();
                config.CreateMap<Vendor, VendorEditVm>();
                config.CreateMap<VendorEditVm, Vendor>();

                config.CreateMap<EmployeeCreateVm, Employee>();
                config.CreateMap<Employee, EmployeeEditVm>();
                config.CreateMap<EmployeeEditVm, Employee>();

                config.CreateMap<AssetTypeCreateVm, AssetType>();
                config.CreateMap<AssetType, AssetTypeEditVm>();
                config.CreateMap<AssetTypeEditVm, AssetType>();

                config.CreateMap<AssetGroupCreateVm, AssetGroup>();
                config.CreateMap<AssetGroup, AssetGroupEditVm>();
                config.CreateMap<AssetGroupEditVm, AssetGroup>();

                config.CreateMap<ManufacturerCreateVm, Manufacturer>();
                config.CreateMap<Manufacturer, ManufacturerEditVm>();
                config.CreateMap<ManufacturerEditVm, Manufacturer>();

                config.CreateMap<AssetModelCreateVm, AssetModel>();
                config.CreateMap<AssetModel, AssetModelEditVm>();
                config.CreateMap<AssetModelEditVm, AssetModel>();

                config.CreateMap<LocationCreateVm, Location>();
                config.CreateMap<Location, LocationEditVm>();
                config.CreateMap<LocationEditVm, Location>();

                config.CreateMap<AssetEntryCreatVm, AssetEntry>();
                config.CreateMap<AssetEntry, AssetEntryEditVm>();
                config.CreateMap<AssetEntryEditVm, AssetEntry>();

                config.CreateMap<CheckOutCreateVm, CheckOut>();
                config.CreateMap<CheckOut, CheckOutEditVm>();
                config.CreateMap<CheckOutEditVm, CheckOut>();

                config.CreateMap<NoteCreateVm, Note>();

                config.CreateMap<FinanceCreateVm, Finance>();

                config.CreateMap<ServiceCreateVm, Service>();

                config.CreateMap<CheckInCreateVm, CheckIn>();

                config.CreateMap<AttachmentCreateVm, Attachment>();

                config.CreateMap<AuditCreateVm, Audit>();
                config.CreateMap<Audit, AuditEditVm>();
                config.CreateMap<AuditEditVm, Audit>();

            });
        }
    }
}
