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
using AutoMapper;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class BranchesController : Controller
    {
        readonly AllDropdown _dropdown = new AllDropdown();
        readonly IBranchManager _branchManager = new BranchManager();
        //private IBranchManager _branchManager;

        //public BranchesController()
        //{
        //    _branchManager = new BranchManager();
        //}

        // GET: Branches
        public ActionResult Index()
        {
            return View(_branchManager.GetAll());
        }


        // GET: Branches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = _branchManager.GetById((int)id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            var entity = new BranchCreateVm
            {
                OrganizationLookUp = _dropdown.GetOrganizations()
            };
            return View(entity);
        }

        // POST: Branches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,OrganizationId")] BranchCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var branch = Mapper.Map<Branch>(entity);
                _branchManager.Add(branch);
                return RedirectToAction("Index");
            }

            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            return View(entity);
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = _branchManager.GetById((int)id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<BranchEditVm>(branch);
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            return View(entity);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,OrganizationId")] BranchEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var branch = Mapper.Map<Branch>(entity);
                _branchManager.Update(branch);
                return RedirectToAction("Index");
            }
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            return View(entity);
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = _branchManager.GetById((int)id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch branch = _branchManager.GetById(id);
            _branchManager.Remove(branch);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _branchManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
