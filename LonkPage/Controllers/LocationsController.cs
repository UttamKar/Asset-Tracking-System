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
using ATS.Models.Models.ViewModel.Location;
using AutoMapper;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class LocationsController : Controller
    {
        AllDropdown _dropdown = new AllDropdown();
        ILocationManager _locationManager=new LocationManager();

        // GET: Locations
        public ActionResult Index()
        {
            return View(_locationManager.GetAll());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = _locationManager.GetById((int)id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            var entity = new LocationCreateVm
            {
                OrganizationLookUp = _dropdown.GetOrganizations(),
                BranchLookUp = _dropdown.GetBranches()
            };
            return View(entity);
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,BranchId,OrganizationId")] LocationCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var location = Mapper.Map<Location>(entity);
                _locationManager.Add(location);
                return RedirectToAction("Index");
            }

            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            return View(entity);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = _locationManager.GetById((int)id);
            if (location == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<LocationEditVm>(location);
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            return View(entity);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,BranchId,OrganizationId")] LocationEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var location = Mapper.Map<Location>(entity);
                _locationManager.Update(location);
                return RedirectToAction("Index");
            }
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            return View(entity);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = _locationManager.GetById((int)id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = _locationManager.GetById(id);
            _locationManager.Remove(location);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _locationManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
