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
using ATS.Models.Models.ViewModel.AssetType;
using AutoMapper;

namespace LonkPage.Controllers
{
    public class AssetTypesController : Controller
    {
        IAssetTypeManager _assetTypeManager = new AssetTypeManager();
        //private IAssetTypeManager _assetTypeManager;

        //public AssetTypesController()
        //{
        //    _assetTypeManager = new AssetTypeManager();
        //}

        // GET: AssetTypes
        public ActionResult Index()
        {
            return View(_assetTypeManager.GetAll());
        }

        // GET: AssetTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetType assetType = _assetTypeManager.GetById((int) id);
            if (assetType == null)
            {
                return HttpNotFound();
            }
            return View(assetType);
        }

        // GET: AssetTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Code")] AssetTypeCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetType = Mapper.Map<AssetType>(entity);
                _assetTypeManager.Add(assetType);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: AssetTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetType assetType = _assetTypeManager.GetById((int) id);
            if (assetType == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<AssetTypeEditVm>(assetType);
            return View(entity);
        }

        // POST: AssetTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Code")] AssetTypeEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetType = Mapper.Map<AssetType>(entity);
                _assetTypeManager.Update(assetType);
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // GET: AssetTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetType assetType = _assetTypeManager.GetById((int) id);
            if (assetType == null)
            {
                return HttpNotFound();
            }
            return View(assetType);
        }

        // POST: AssetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetType assetType = _assetTypeManager.GetById(id);
            _assetTypeManager.Remove(assetType);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _assetTypeManager.Dispose();
            }
            base.Dispose(disposing);
        }


        //Get: Search 
        public ActionResult Search()
        {
            var model = new AssetTypeSearchVm();
            return View(model);
        }

        //Post: Search 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(AssetTypeSearchVm model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.AssetTypes = _assetTypeManager.Search(model);
            }

            if (model == null)
            {
                model = new AssetTypeSearchVm();
            }

            return View(model);
        }



    }

}
