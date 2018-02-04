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
using ATS.Models.Models.ViewModel.CheckIn;
using AutoMapper;
using LonkPage.Dropdowns;
using CheckOutAssetList = ATS.Models.Migrations.CheckOutAssetList;

namespace LonkPage.Controllers
{
    public class CheckInsController : Controller
    {
        private readonly ICheckInManager _checkInManager=new CheckInManager();
        private readonly AllDropdown _dropdown=new AllDropdown();
        private readonly IAssetEntryManager _assetEntryManager = new AssetEntryManager();
        private readonly ICheckOutAssetListManager _checkOutAssetListManager=new CheckOutAssetListManager();
        private readonly IAssetDetailsManager _assetDetailsManager = new AssetDetailsManager();
        private readonly ICheckInAssetListManager _checkInAssetListManager=new CheckInAssetListManager();


        // GET: CheckIns
        public ActionResult Index()
        {
            return View(_checkInManager.GetAll());
        }

        // GET: CheckIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = _checkInManager.GetById((int)id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            return View(checkIn);
        }

        // GET: CheckIns/Create
        public ActionResult Create()
        {
            var model=new CheckInCreateVm()
            {
                EmployeeLookup = _dropdown.GetEmployees()
            };
            return View(model);
        }

        // POST: CheckIns/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CheckInCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                
                var checkIn = Mapper.Map<CheckIn>(entity);
                _checkInManager.Add(checkIn);

                var str = entity.assetIDArr;
                string[] idsArray = str.Split(',');
                foreach (var item in idsArray)
                {

                    
                    
                    for (int i = 0; i < 1; i++)
                    {
                        int id = Convert.ToInt32(item);
                        var desiredAsset = _checkInManager.GetAssetById(id);
                        string[] assetName = desiredAsset.Select(I => I.Name).ToArray();
                        string[] assetNo = desiredAsset.Select(I => I.AssetNo).ToArray();
                        DateTime[] dueDate = desiredAsset.Select(I => I.DueDate).ToArray();



                        //To save checkInAssetList
                        CheckInAssetList checkInAssetList = new CheckInAssetList();
                        checkInAssetList.AssetNo = assetNo[i];
                        checkInAssetList.Name = assetName[i];
                        checkInAssetList.DueDate = dueDate[i];
                        checkInAssetList.CheckInId = checkIn.Id;
                        checkInAssetList.AssetEntryId = id;
                        _checkInAssetListManager.Add(checkInAssetList);

                        //To update asset status in Asset table
                        var asset = _assetEntryManager.GetById(id);
                        asset.Status = "2";
                        _assetEntryManager.Update(asset);


                        //For AssetDetails Table
                        ATSDBContext db = new ATSDBContext();
                        AssetDetails assetDetails = new AssetDetails();
                        assetDetails.DescriptionName = assetName[i];
                        assetDetails.SerialNo = assetNo[i];
                        assetDetails.AssetEntryId = id;
                        assetDetails.EntryDate = DateTime.Now.ToShortDateString();
                        assetDetails.Status = "2";
                        assetDetails.EmployeeId = entity.EmployeeId;
                        db.AssetDetailses.Add(assetDetails);
                        db.SaveChanges();


                        //To Remove Asset from CheckOutAssetList table
                        var deleteableAsset = db.CheckOutAssetLists.FirstOrDefault(c => c.AssetEntryId == id);
                        if (deleteableAsset != null)
                        {
                            db.CheckOutAssetLists.Remove(deleteableAsset);
                            db.SaveChanges();
                        }
                    }

                }

                return RedirectToAction("Index");
                }

                return View(entity);
            }



        // GET: CheckIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = _checkInManager.GetById((int)id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            return View(checkIn);
        }


        // POST: CheckIns/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comments,SetLocation,CheckInStatus,AssetNo,Description,AssetEntryId,EmployeeId,DueDate,CheckOutAssetListId")] CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                _checkInManager.Update(checkIn);
                return RedirectToAction("Index");
            }
            return View(checkIn);
        }

        // GET: CheckIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = _checkInManager.GetById((int)id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            return View(checkIn);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckIn checkIn = _checkInManager.GetById(id);
            _checkInManager.Remove(checkIn);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _checkInManager.Dispose();
            }
            base.Dispose(disposing);
        }


        //To pull all assets against an Employee
        public JsonResult SearchAssetForCheckIn(int id)
        {
            var jsonItems = _checkInManager.SearchAssetForCheckIn(id);
            return Json(jsonItems, JsonRequestBehavior.AllowGet);
        }

    }
}
