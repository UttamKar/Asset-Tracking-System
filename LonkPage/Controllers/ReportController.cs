using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Models.ViewModel.SP;
using Microsoft.Reporting.WebForms;

namespace LonkPage.Controllers
{
    public class ReportController : Controller
    {
        IAssetEntryManager _assetEntryManager=new AssetEntryManager();
        private ICheckOutManager _checkOutManager = new CheckOutManager();

        //For AssetList Report
        public ActionResult AssetList(string name)
        {
            ICollection<SP_AssetList> assetList = _assetEntryManager.GetAssetListReport(name);
            ReportViewer reportViewer=new ReportViewer()
            {
                KeepSessionAlive = true,
                SizeToReportContent = true,
                Width = Unit.Percentage(100),
                ProcessingMode = ProcessingMode.Local
            };

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Report\AssetList.rdlc";
            ReportDataSource ds=new ReportDataSource("DS_AssetTable", assetList);
            reportViewer.LocalReport.DataSources.Add(ds);

            ViewBag.ReportViewer = reportViewer;

            return View();
        }



        //For CheckOutList Report
        public ActionResult CheckOutList(string name)
        {
            ICollection<SP_CheckOutList> checkOutList = _checkOutManager.GetCheckOutListReport(name);
            ReportViewer reportViewer = new ReportViewer()
            {
                KeepSessionAlive = true,
                SizeToReportContent = true,
                Width = Unit.Percentage(100),
                ProcessingMode = ProcessingMode.Local
            };

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Report\CheckOutList.rdlc";
            ReportDataSource ds = new ReportDataSource("DS_CheckOutList", checkOutList);
            reportViewer.LocalReport.DataSources.Add(ds);

            ViewBag.ReportViewer = reportViewer;

            return View();
        }

    }
}