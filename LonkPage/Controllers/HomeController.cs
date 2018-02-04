using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATS.Models.DatabaseContext;

namespace LonkPage.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "User Signed In: " + User.Identity.Name;
        }






        






        public ActionResult AssetEdit()
        {
            return View("AssetEdit");
        }
        public PartialViewResult AssetEditAttachmentPartial()
        {
            return PartialView("~/Views/Shared/ATS/AssetEdit/_Attachment.cshtml");
        }
        public ActionResult CheckOut()
        {
            return View("CheckOut");
        }
        public PartialViewResult CheckOutElectronicsPartial()
        {
            return PartialView("~/Views/Shared/ATS/CheckOut/_CheckOutElectuonics.cshtml");
        }
        public PartialViewResult CheckOutFurniturePartial()
        {
            return PartialView("~/Views/Shared/ATS/CheckOut/_CheckOutFurniture.cshtml");
        }
        public ActionResult CheckIn()
        {
            return View("CheckIn");
        }
        public PartialViewResult CheckInEmployeePartial()
        {
            return PartialView("~/Views/Shared/ATS/CheckIn/_CheckInEmployee.cshtml");
        }
        public PartialViewResult CheckInLocatianPartial()
        {
            return PartialView("~/Views/Shared/ATS/CheckIn/_CheckInLocation.cshtml");
        }
        public ActionResult AssetAudit()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View("CreateUser");
        }


    }
}