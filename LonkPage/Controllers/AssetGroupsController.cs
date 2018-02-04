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
using ATS.Models.Models;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.AssetGroup;
using AutoMapper;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class AssetGroupsController : Controller
    {
        AllDropdown _dropdown=new AllDropdown();
        IAssetGroupManager _assetGroupManager=new AssetGroupManager();

        // GET: AssetGroups
        public ActionResult Index()
        {
            return View(_assetGroupManager.GetAll());
        }

        // GET: AssetGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetGroup assetGroup = _assetGroupManager.GetById((int)id);
            if (assetGroup == null)
            {
                return HttpNotFound();
            }
            return View(assetGroup);
        }

        // GET: AssetGroups/Create
        public ActionResult Create()
        {
            var entity = new AssetGroupCreateVm
            {
                AssetTypeLookup = _dropdown.GetAssetTypes()
            };
            return View(entity);
        }

        // POST: AssetGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Code,AssetTypeId")] AssetGroupCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetGroup = Mapper.Map<AssetGroup>(entity);
                _assetGroupManager.Add(assetGroup);
                return RedirectToAction("Index");
            }

            entity.AssetTypeLookup = _dropdown.GetAssetTypes();
            return View(entity);
        }

        // GET: AssetGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetGroup assetGroup = _assetGroupManager.GetById((int)id);
            if (assetGroup == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<AssetGroupEditVm>(assetGroup);
            entity.AssetTypeLookup = _dropdown.GetAssetTypes();
            return View(entity);
        }

        // POST: AssetGroups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Code,AssetTypeId")] AssetGroupEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetGroup = Mapper.Map<AssetGroup>(entity);
                _assetGroupManager.Update(assetGroup);
                return RedirectToAction("Index");
            }
            entity.AssetTypeLookup = _dropdown.GetAssetTypes();
            return View(entity);
        }

        // GET: AssetGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetGroup assetGroup = _assetGroupManager.GetById((int)id);
            if (assetGroup == null)
            {
                return HttpNotFound();
            }
            return View(assetGroup);
        }

        // POST: AssetGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetGroup assetGroup = _assetGroupManager.GetById(id);
            _assetGroupManager.Remove(assetGroup);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _assetGroupManager.Dispose();
            }
            base.Dispose(disposing);
        }


        //Get: Search
        public ActionResult Search()
        {
            var model = new AssetGroupSearchVm();
            {
                model.AssetTypeLookup = _dropdown.GetAssetGroups();
            }
            return View(model);
        }

        //Post: Search 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(AssetGroupSearchVm model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.AssetGroups = _assetGroupManager.Search(model);
            }

            if (model == null)
            {
                model = new AssetGroupSearchVm();
            }
            //model.AssetGroups = _assetGroupManager.Search(model);
            model.AssetTypeLookup = _dropdown.GetAssetGroups();
            return View(model);
        }



    }
}
