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
using ATS.Models.Models.ViewModel.AssetModel;
using AutoMapper;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class AssetModelsController : Controller
    {
        AllDropdown _dropdown=new AllDropdown();
        IAssetModelManager _assetModelManager=new AssetModelManager();

        // GET: AssetModels
        public ActionResult Index()
        {
            return View(_assetModelManager.GetAll());
        }

        // GET: AssetModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetModel assetModel = _assetModelManager.GetById((int)id);
            if (assetModel == null)
            {
                return HttpNotFound();
            }
            return View(assetModel);
        }

        // GET: AssetModels/Create
        public ActionResult Create()
        {
            var entity = new AssetModelCreateVm
            {
                AssetGroupLookUp = _dropdown.GetAssetGroups(),
                ManufacturerLookUp = _dropdown.GetManufacturers()
            };
            return View(entity);
        }



        // POST: AssetModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Code,Description,AssetGroupId,ManufacturerId")] AssetModelCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetModel = Mapper.Map<AssetModel>(entity);
                _assetModelManager.Add(assetModel);
                return RedirectToAction("Index");
            }

            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            entity.ManufacturerLookUp = _dropdown.GetManufacturers();
            return View(entity);
        }



        // GET: AssetModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetModel assetModel = _assetModelManager.GetById((int)id);
            if (assetModel == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<AssetModelEditVm>(assetModel);
            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            entity.ManufacturerLookUp = _dropdown.GetManufacturers();
            return View(entity);
        }



        // POST: AssetModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Code,Description,AssetGroupId,ManufacturerId")] AssetModelEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetModel = Mapper.Map<AssetModel>(entity);
                _assetModelManager.Update(assetModel);
                return RedirectToAction("Index");
            }
            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            entity.ManufacturerLookUp = _dropdown.GetManufacturers();
            return View(entity);
        }



        // GET: AssetModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetModel assetModel = _assetModelManager.GetById((int)id);
            if (assetModel == null)
            {
                return HttpNotFound();
            }
            return View(assetModel);
        }



        // POST: AssetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetModel assetModel = _assetModelManager.GetById((int)id);
            _assetModelManager.Remove(assetModel);
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _assetModelManager.Dispose();
            }
            base.Dispose(disposing);
        }


        //Get: Search
        public ActionResult Search()
        {
            var model = new AssetModelSearchVm();
            {
                model.AssetGroupLookUp = _dropdown.GetAssetGroups();
                model.ManufacturerLookUp = _dropdown.GetManufacturers();
            }
            return View(model);
        }

        //Post: Search 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(AssetModelSearchVm model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.AssetModels = _assetModelManager.Search(model);
            }

            if (model == null)
            {
                model = new AssetModelSearchVm();
            }
            //model.AssetModels = _assetModelManager.Search(model);
            model.AssetGroupLookUp = _dropdown.GetAssetGroups();
            model.ManufacturerLookUp = _dropdown.GetManufacturers();
            return View(model);
        }


    }
}
