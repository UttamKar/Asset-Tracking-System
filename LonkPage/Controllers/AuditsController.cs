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
using ATS.Models.Models.ViewModel.Audit;
using AutoMapper;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class AuditsController : Controller
    {
        readonly IAuditManager _auditManager=new AuditManager();
        readonly AllDropdown _dropdown = new AllDropdown();

        // GET: Audits
        public ActionResult Index()
        {
            return View(_auditManager.GetAll());
        }

        // GET: Audits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = _auditManager.GetById((int)id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // GET: Audits/Create
        public ActionResult Create()
        {
            var entity = new AuditCreateVm()
            {
                LocationLookUp = _dropdown.GetLocations()
            };
            return View(entity);
        }

        // POST: Audits/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(AuditCreateVm entity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var assetAudit = Mapper.Map<Audit>(entity);
        //        _auditManager.Add(assetAudit);
        //        return RedirectToAction("Index");
        //    }
        //    entity.LocationLookUp = _dropdown.GetLocations();
        //    return View(entity);
        //}

        public JsonResult AuditDataSave(AuditCreateVm entity)
        {
            var auditData = Mapper.Map<Audit>(entity);
            _auditManager.Add(auditData);

            return Json(auditData, JsonRequestBehavior.AllowGet);
        }



        // GET: Audits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = _auditManager.GetById((int)id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            var entity = Mapper.Map<AuditEditVm>(audit);
            entity.LocationLookUp = _dropdown.GetLocations();
            return View(entity);
        }

        // POST: Audits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuditEditVm entity)
        {
            if (ModelState.IsValid)
            {
                var assetAudit = Mapper.Map<Audit>(entity);
                _auditManager.Update(assetAudit);
                return RedirectToAction("Index");
            }
            entity.LocationLookUp = _dropdown.GetLocations();
            return View(entity);
        }

        // GET: Audits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = _auditManager.GetById((int)id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // POST: Audits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Audit audit = _auditManager.GetById(id);
            _auditManager.Remove(audit);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _auditManager.Dispose();
            }
            base.Dispose(disposing);
        }



        //To pull all assets on a location
        public JsonResult SearchAssetByLocationId(int id)
        {
            var jsonItems = _auditManager.SearchAssetByLocationId(id);
            return Json(jsonItems, JsonRequestBehavior.AllowGet);
        }


        
    }
}
