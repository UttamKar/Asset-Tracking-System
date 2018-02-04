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
using ATS.Models.Models.ViewModel.Branch;
using ATS.Models.Models.ViewModel.Vendor;
using AutoMapper;
using PagedList;
using PagedList.Mvc;

namespace LonkPage.Controllers
{
    public class VendorsController : Controller
    {
        IVendorManager _vendorManager = new VendorManager();



        //GET: Vendors
        public ActionResult Index(int? page)
        {
            return View(_vendorManager.GetAll().OrderByDescending(m => m.Id).ToPagedList(page ?? 1, 3));
        }


        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.GetById((int)id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Vendors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Email,ContactNo,Address,Comments")] VendorCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var vendor = Mapper.Map<Vendor>(entity);
                _vendorManager.Add(vendor);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.GetById((int)id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<VendorEditVm>(vendor);
            return View(entity);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Email,ContactNo,Address,Comments")] VendorEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var vendor = Mapper.Map<Vendor>(entity);
                _vendorManager.Update(vendor);
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.GetById((int)id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = _vendorManager.GetById(id);
            _vendorManager.Remove(vendor);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _vendorManager.Dispose();
            }
            base.Dispose(disposing);
        }



        //Get: Search 
        public ActionResult Search()
        {
            var model = new VendorSearchVm();
            return View(model);
        }

        //Post: Search 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(VendorSearchVm model, int? page)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Vendors = _vendorManager.Search(model);
            }

            if (model == null)
            {
                model = new VendorSearchVm();
            }

            return View(model);
        }

    }
}
