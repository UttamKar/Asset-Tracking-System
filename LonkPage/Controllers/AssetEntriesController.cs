using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATS.BLL;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Migrations;
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Models.Models.ViewModel.AssetEntry;
using ATS.Models.Models.ViewModel.PartialView;
using AutoMapper;
using LonkPage.Dropdowns;
using Attachment = ATS.Models.Migrations.Attachment;

namespace LonkPage.Controllers
{
    [Authorize]
    public class AssetEntriesController : Controller
    {
        private readonly AllDropdown _dropdown=new AllDropdown();
        private readonly IAssetEntryManager _assetEntryManager=new AssetEntryManager();
        private readonly INoteManager _noteManager = new NoteManager();
        private readonly IFinanceManager _financeManager = new FinanceManager();
        private readonly IServiceManager _serviceManager=new ServiceManager();
        private readonly IAttachmentManager _attachmentManager= new AttachmentManager();
        private readonly IAssetDetailsManager _assetDetailsManager =new AssetDetailsManager();


        // GET: AssetEntries
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_assetEntryManager.GetAll());
        }

        // GET: AssetEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetEntry assetEntry = _assetEntryManager.GetById((int)id);
            if (assetEntry == null)
            {
                return HttpNotFound();
            }
            return View(assetEntry);
        }

        // GET: AssetEntries/Create
        public ActionResult Create()
        {
            var entity = new AssetEntryCreatVm
            {
                OrganizationLookUp = _dropdown.GetOrganizations(),
                BranchLookUp = _dropdown.GetBranches(),
                LocationLookUp=_dropdown.GetLocations(),
                AssetTypeLookUp = _dropdown.GetAssetTypes(),
                AssetGroupLookUp = _dropdown.GetAssetGroups(),
                ManufacturerLookUp = _dropdown.GetManufacturers(),
                AssetModelLookUp=_dropdown.GetAssetModels()
            };
            return View(entity);
        }

        // POST: AssetEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase Attachment, AssetEntryCreatVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetEntry = Mapper.Map<AssetEntry>(entity);

                assetEntry.Attachment = "/UploadedDocuments/AssetEntryFiles/" + DateTime.Now.ToString("yyyy-M-d dddd") + "_" + assetEntry.Brand + System.IO.Path.GetExtension(Attachment.FileName);
                Attachment.SaveAs(Server.MapPath(assetEntry.Attachment));

                _assetEntryManager.Add(assetEntry);


                //For AssetDetails Table
                ATSDBContext db=new ATSDBContext();
                AssetDetails assetDetails = new AssetDetails();
                assetDetails.DescriptionName = entity.DescriptionName;
                assetDetails.SerialNo = entity.SerialNo;
                assetDetails.AssetEntryId = assetEntry.Id;
                assetDetails.EntryDate = DateTime.Now.ToShortDateString();
                assetDetails.Status = entity.Status;
                db.AssetDetailses.Add(assetDetails);
                db.SaveChanges();


                return RedirectToAction("Edit",new {id= assetEntry.Id});
            }

            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            entity.LocationLookUp = _dropdown.GetLocations();
            entity.AssetTypeLookUp = _dropdown.GetAssetTypes();
            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            entity.ManufacturerLookUp = _dropdown.GetManufacturers();
            entity.AssetModelLookUp = _dropdown.GetAssetModels();
            return View(entity);
        }

        // GET: AssetEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetEntry assetEntry = _assetEntryManager.GetById((int)id);
            if (assetEntry == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<AssetEntryEditVm>(assetEntry);
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            entity.LocationLookUp = _dropdown.GetLocations();
            entity.AssetTypeLookUp = _dropdown.GetAssetTypes();
            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            entity.ManufacturerLookUp = _dropdown.GetManufacturers();
            entity.AssetModelLookUp = _dropdown.GetAssetModels();
            return View(entity);
        }

        // POST: AssetEntries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase Attachment, [Bind(Include = "Id,Brand,SerialNo,DescriptionName,AssetModelId,Status,Attachment,LocationId,BranchId,OrganizationId,ManufacturerId,AssetGroupId,AssetTypeId")] AssetEntryEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetEntry = Mapper.Map<AssetEntry>(entity);

                assetEntry.Attachment = "/UploadedDocuments/AssetEntryFiles/" + DateTime.Now.ToString("yyyy-M-d dddd") + "_" + assetEntry.Brand + System.IO.Path.GetExtension(Attachment.FileName);
                Attachment.SaveAs(Server.MapPath(assetEntry.Attachment));

                _assetEntryManager.Update(assetEntry);

                //For AssetDetails Table
                ATSDBContext db = new ATSDBContext();
                AssetDetails assetDetails = new AssetDetails();
                assetDetails.DescriptionName = entity.DescriptionName;
                assetDetails.SerialNo = entity.SerialNo;
                assetDetails.AssetEntryId = assetEntry.Id;
                assetDetails.EntryDate = DateTime.Now.ToShortDateString();
                assetDetails.Status = entity.Status;
                db.AssetDetailses.Add(assetDetails);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            entity.LocationLookUp = _dropdown.GetLocations();
            entity.AssetTypeLookUp = _dropdown.GetAssetTypes();
            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            entity.ManufacturerLookUp = _dropdown.GetManufacturers();
            entity.AssetModelLookUp = _dropdown.GetAssetModels();
            return View(entity);
        }

        // GET: AssetEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetEntry assetEntry = _assetEntryManager.GetById((int)id);
            if (assetEntry == null)
            {
                return HttpNotFound();
            }
            return View(assetEntry);
        }

        // POST: AssetEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetEntry assetEntry = _assetEntryManager.GetById(id);

            //To remove previous Attachment from folder
            string fullPath = Request.MapPath(assetEntry.Attachment);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            _assetEntryManager.Remove(assetEntry);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _assetEntryManager.Dispose();
            }
            base.Dispose(disposing);
        }



        //Lode Notes Partially
        public PartialViewResult AssetEditNotesPartial()
        {
            return PartialView("~/Views/Shared/ATS/AssetEdit/_Notes.cshtml");
        }
        //Add Notes Partially
        public JsonResult AddNotes(NoteCreateVm entity)
        {
            var note = Mapper.Map<Note>(entity);
            _noteManager.Add(note);

            return Json(note, JsonRequestBehavior.AllowGet);
        }



        //Load Service Partially
        public PartialViewResult AssetEditServicePartial(int id)
        {
            var entity = new ServiceCreateVm()
            {
                Services = _serviceManager.GetServiceDetails(id)
            };
            return PartialView("~/Views/Shared/ATS/AssetEdit/_Service.cshtml", entity);
        }
        //Add Service Partially
        public JsonResult AddServices(ServiceCreateVm entity)
        {
            var service = Mapper.Map<Service>(entity);
            _serviceManager.Add(service);
            return Json(service, JsonRequestBehavior.AllowGet);
        }



        //Load Finance Partially
        public PartialViewResult AssetEditFinancePartial()
        {
            var entity = new FinanceCreateVm
            {
                VendorLookUp = _dropdown.GetVendors()
            };
            return PartialView("~/Views/Shared/ATS/AssetEdit/_Finance.cshtml", entity);
        }

        //Add Finance Partially
        public JsonResult AddFinance(FinanceCreateVm entity)
        {
            var finance = Mapper.Map<Finance>(entity);
            _financeManager.Add(finance);
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        //For Asset History Partial
        public PartialViewResult AssetEditHistoryPartial(int id)
        {
            return PartialView("~/Views/Shared/ATS/AssetEdit/_History.cshtml", _assetDetailsManager.GetAllAssetDetails(id));
        }


        [HttpPost]
        public JsonResult Upload( AttachmentCreateVm entity)
        {
            var attachment = Mapper.Map<Attachment>(entity);
            //attachment.File = "/UploadedDocuments/AssetEntryFiles/" + DateTime.Now.ToString("yyyy-M-d dddd") + "_" + System.IO.Path.GetExtension(file.FileName);
            //file.SaveAs(Server.MapPath(attachment.File));

            _attachmentManager.Add(attachment);
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

    }
}
