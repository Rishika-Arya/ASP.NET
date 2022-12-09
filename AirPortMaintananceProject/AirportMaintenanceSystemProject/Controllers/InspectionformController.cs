using AirportMaintenanceSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMaintenanceSystemProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public partial class InspectionformController : Controller
    {
        AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
        // GET: Inspections


        [HttpGet]
        public ActionResult AddNewInspection()
        {
            var list = new List<string>() { "Completed", "Pending", "In-Process" };
            ViewBag.Inspections = list;
            return View();
        }

        [HttpPost]
        public ActionResult AddNewInspection(Inspection model)
        {

            context.Inspections.Add(model);
            context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("AddNewInspection");
        }



    }
}
     

