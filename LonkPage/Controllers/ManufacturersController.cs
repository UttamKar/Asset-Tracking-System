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
using ATS.Models.Models.ViewModel.Manufacturer;
using AutoMapper;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class ManufacturersController : Controller
    {
        AllDropdown _dropdown=new AllDropdown();
        IManufacturerManager _manufacturerManager=new ManufacturerManager();

        // GET: Manufacturers
        public ActionResult Index()
        {
            return View(_manufacturerManager.GetAll());
        }

        // GET: Manufacturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = _manufacturerManager.GetById((int)id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Create
        public ActionResult Create()
        {
            var entity = new ManufacturerCreateVm()
            {
                AssetGroupLookUp = _dropdown.GetAssetGroups()
            };
            return View(entity);
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Code,Description,AssetGroupId")] ManufacturerCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var manufacturer = Mapper.Map<Manufacturer>(entity);
                _manufacturerManager.Add(manufacturer);
                return RedirectToAction("Index");
            }

            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            return View(entity);
        }

        // GET: Manufacturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = _manufacturerManager.GetById((int)id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<ManufacturerEditVm>(manufacturer);
            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            return View(entity);
        }

        // POST: Manufacturers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Code,Description,AssetGroupId")] ManufacturerEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var manufacturer = Mapper.Map<Manufacturer>(entity);
                _manufacturerManager.Update(manufacturer);
                return RedirectToAction("Index");
            }
            entity.AssetGroupLookUp = _dropdown.GetAssetGroups();
            return View(entity);
        }

        // GET: Manufacturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = _manufacturerManager.GetById((int)id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = _manufacturerManager.GetById(id);
            _manufacturerManager.Remove(manufacturer);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _manufacturerManager.Dispose();
            }
            base.Dispose(disposing);
        }




        //Get: Search
        public ActionResult Search()
        {
            var model = new ManufacturerSearchVm();
            {
                model.AssetGroupLookUp = _dropdown.GetAssetGroups();
            }
            return View(model);
        }

        //Post: Search 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(ManufacturerSearchVm model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Manufacturers = _manufacturerManager.Search(model);
            }

            if (model == null)
            {
                model = new ManufacturerSearchVm();
            }
            model.AssetGroupLookUp = _dropdown.GetAssetGroups();
            return View(model);
        }
    }
}
