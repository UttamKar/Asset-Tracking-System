using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATS.BLL;
using ATS.Models.DatabaseContext;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.EntityModel.Partial;
using ATS.Models.Models.ViewModel.CheckOut;
using AutoMapper;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class CheckOutsController : Controller
    {
        readonly AllDropdown _dropdown = new AllDropdown();
        readonly ICheckOutManager _checkOutManager=new CheckOutManager();
        readonly IAssetEntryManager _assetEntryManager=new AssetEntryManager();
        private readonly IAssetDetailsManager _assetDetailsManager = new AssetDetailsManager();
        ICheckInAssetListManager _checkInAssetListManager=new CheckInAssetListManager();
        // GET: CheckOuts
        public ActionResult Index()
        {
            return View(_checkOutManager.GetAll());
        }

        // GET: CheckOuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = _checkOutManager.GetById((int)id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            return View(checkOut);
        }

        //GET: CheckOuts/Create
        public ActionResult Create()
        {

            var entity = new CheckOutCreateVm
            {
                EmployeeLookUp = _dropdown.GetEmployees(),
                LocationLookUp = _dropdown.GetLocations(),
                AssetEntryLookUp = _dropdown.GetAssetsForCheckOut()
            };
            return View(entity);
        }


        // POST: CheckOuts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CheckOutCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var checkOut = Mapper.Map<CheckOut>(entity);
                _checkOutManager.Add(checkOut);

                


                var checkOutAssetLists = entity.CheckOutAssetLists;
                int[] array = checkOutAssetLists.Select(I => I.AssetEntryId).ToArray();
                string[] assetNameArray = checkOutAssetLists.Select(I => I.Name).ToArray();
                string[] assetNoArray = checkOutAssetLists.Select(I => I.AssetNo).ToArray();
                //int assetId = 0;
                for (int i = 0; i < checkOutAssetLists.Count; i++)
                {
                    //To update asset status in asset table
                    int assetId = array[i];
                    var asset = _assetEntryManager.GetById(assetId);
                    asset.Status = "3";
                    _assetEntryManager.Update(asset);



                    //For AssetDetails Table
                    ATSDBContext db = new ATSDBContext();

                    AssetDetails assetDetails = new AssetDetails();
                    assetDetails.DescriptionName = assetNameArray[i];
                    assetDetails.SerialNo = assetNoArray[i];
                    assetDetails.AssetEntryId = array[i];
                    assetDetails.EntryDate = DateTime.Now.ToShortDateString();
                    assetDetails.Status = "3";
                    assetDetails.EmployeeId = entity.EmployeeId;
                    db.AssetDetailses.Add(assetDetails);
                    db.SaveChanges();


                    //To Remove Asset from CheckInAssetList table (if available)
                    var deleteableAsset = _checkInAssetListManager.GetAssetByAssetId(assetId);
                    if (deleteableAsset != null)
                    {
                        _checkInAssetListManager.Remove(deleteableAsset);
                    }

                }

                return RedirectToAction("Index");
            }

            entity.EmployeeLookUp = _dropdown.GetEmployees();
            entity.LocationLookUp = _dropdown.GetLocations();
            entity.AssetEntryLookUp = _dropdown.GetAssetsForCheckOut();
            return View(entity);
        }

        // GET: CheckOuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = _checkOutManager.GetById((int)id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<CheckOutEditVm>(checkOut);
            entity.EmployeeLookUp = _dropdown.GetEmployees();
            entity.LocationLookUp = _dropdown.GetLocations();
            entity.AssetEntryLookUp = _dropdown.GetAssetsForCheckOut();
            return View(entity);
        }

        // POST: CheckOuts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CheckOutEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var checkOut = Mapper.Map<CheckOut>(entity);
                _checkOutManager.Update(checkOut);

                //To update asset status in asset table
                var checkOutAssetLists = entity.CheckOutAssetLists;
                int[] array = checkOutAssetLists.Select(I => I.AssetEntryId).ToArray();
                int assetId = 0;
                for (int i = 0; i < checkOutAssetLists.Count; i++)
                {
                    assetId = array[i];
                    var asset = _assetEntryManager.GetById(assetId);
                    asset.Status = "3";
                    _assetEntryManager.Update(asset);
                }

                //For AssetDetails Table
                ATSDBContext db = new ATSDBContext();
                string[] assetNameArray = checkOutAssetLists.Select(I => I.Name).ToArray();
                string[] assetNoArray = checkOutAssetLists.Select(I => I.AssetNo).ToArray();

                for (int i = 0; i < checkOutAssetLists.Count; i++)
                {
                    AssetDetails assetDetails = new AssetDetails();
                    assetDetails.DescriptionName = assetNameArray[i];
                    assetDetails.SerialNo = assetNoArray[i];
                    assetDetails.AssetEntryId = array[i];
                    assetDetails.EntryDate = DateTime.Now.ToShortDateString();
                    assetDetails.Status = "3";
                    assetDetails.EmployeeId = entity.EmployeeId;
                    db.AssetDetailses.Add(assetDetails);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            entity.EmployeeLookUp = _dropdown.GetEmployees();
            entity.LocationLookUp = _dropdown.GetLocations();
            entity.AssetEntryLookUp = _dropdown.GetAssetsForCheckOut();
            return View(entity);
        }

        // GET: CheckOuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = _checkOutManager.GetById((int)id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            return View(checkOut);
        }

        // POST: CheckOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckOut checkOut = _checkOutManager.GetById(id);
            _checkOutManager.Remove(checkOut);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _checkOutManager.Dispose();
            }
            base.Dispose(disposing);
        }


        //For Location-Add Partial
        public PartialViewResult LocationAddPartial()
        {
            return PartialView("~/Views/Shared/ATS/CheckOut/_LocationAdd.cshtml");
        }
        
    }
}
