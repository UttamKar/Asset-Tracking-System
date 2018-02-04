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
using ATS.Models.Models.ViewModel;
using ATS.Models.Models.ViewModel.Organization;
using AutoMapper;

namespace LonkPage.Controllers
{
    public class OrganizationsController : Controller
    {

        IOrganizationManager _organizationManager=new OrganizationManager();
        //private IOrganizationManager _organizationManager;

        //public OrganizationsController()
        //{
        //    _organizationManager=new OrganizationManager();
        //}


        //GET: Organizations
        public ActionResult Index()
        {
            return View(_organizationManager.GetAll());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int)id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Location")] OrganizationCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var organization = Mapper.Map<Organization>(entity);
                _organizationManager.Add(organization);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int)id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<OrganizationEditVm>(organization);

            return View(entity);
        }


        // POST: Organizations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Location")] OrganizationEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var organization = Mapper.Map<Organization>(entity);
                _organizationManager.Update(organization);
                return RedirectToAction("Index");
            }
            return View(entity);
        }


        // GET: Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int)id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = _organizationManager.GetById(id);
            _organizationManager.Remove(organization);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _organizationManager.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
