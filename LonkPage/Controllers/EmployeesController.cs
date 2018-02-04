using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATS.Models.DatabaseContext;
using ATS.Models.Models;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Models.EntityModel;
using ATS.Models.Models.ViewModel.Employee;
using AutoMapper;
using LonkPage.Dropdowns;

namespace LonkPage.Controllers
{
    public class EmployeesController : Controller
    {
        AllDropdown _dropdown = new AllDropdown();
        IEmployeeManager _employeeManager = new EmployeeManager();



        // GET: Employees
        public ActionResult Index()
        {
            return View(_employeeManager.GetAll());
        }



        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }



        // GET: Employees/Create
        public ActionResult Create()
        {
            var entity = new EmployeeCreateVm
            {
                OrganizationLookUp  = _dropdown.GetOrganizations(),
                BranchLookUp = _dropdown.GetBranches()
            };
            return View(entity);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase Image, [Bind(Include = "Id,FirstName,LastName,Email,ContactNo,Department,Designation,Address,Image,Code,BranchId,OrganizationId")] EmployeeCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var employee = Mapper.Map<Employee>(entity);

                employee.Image = "/UploadedDocuments/Image/" + DateTime.Now.ToString("yyyy-M-d dddd") + "_" + employee.FirstName + "_" + employee.LastName + System.IO.Path.GetExtension(Image.FileName);
                Image.SaveAs(Server.MapPath(employee.Image));

                _employeeManager.Add(employee);
                return RedirectToAction("Index");
            }
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            return View(entity);
        }



        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            
            var entity = Mapper.Map<EmployeeEditVm>(employee);
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            return View(entity);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase Image, EmployeeEditVm entity, int id)
        {
            if (ModelState.IsValid)
            {
                var employee = Mapper.Map<Employee>(entity);

                if (employee.Image != null)
                {
                    employee.Image = "/UploadedDocuments/Image/" + DateTime.Now.ToString("yyyy-M-d dddd") + "_" +
                                     employee.FirstName + "_" + employee.LastName +
                                     System.IO.Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath(employee.Image));
                }

                else
                {
                    var db = new ATSDBContext();
                    var oldData = db.Employees.FirstOrDefault(m => m.Id == id);
                    employee.Image = oldData.Image;
                    db.Entry(oldData).CurrentValues.SetValues(employee);
                }

                _employeeManager.Update(employee);
                return RedirectToAction("Index");
            }
            entity.OrganizationLookUp = _dropdown.GetOrganizations();
            entity.BranchLookUp = _dropdown.GetBranches();
            return View(entity);
        }



        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _employeeManager.GetById(id);

            //To remove previous image from image folder
            string fullPath = Request.MapPath(employee.Image);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            _employeeManager.Remove(employee);
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _employeeManager.Dispose();
            }
            base.Dispose(disposing);
        }


        //Get: Search
        public ActionResult Search()
        {
            var model = new EmployeeSearchVm();
            {
                model.OrganizationLookUp = _dropdown.GetOrganizations();
                model.BranchLookUp = _dropdown.GetBranches();
            }
            return View(model);
        }

        //Post: Search 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(EmployeeSearchVm model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Employees = _employeeManager.Search(model);
            }

            if (model == null)
            {
                model = new EmployeeSearchVm();
            }
            //model.Employees = _employeeManager.Search(model);
            model.OrganizationLookUp = _dropdown.GetOrganizations();
            model.BranchLookUp = _dropdown.GetBranches();
            return View(model);
        }
        
    }
}
