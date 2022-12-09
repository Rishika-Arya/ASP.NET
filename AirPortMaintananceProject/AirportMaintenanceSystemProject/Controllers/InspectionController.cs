using AirportMaintenanceSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMaintenanceSystemProject.Controllers
{
    [Authorize]
    public partial class InspectionController : Controller
    {
        AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
        // GET: Inspections
        public ActionResult InspectionList()
        {
            var listofData = context.Inspections.ToList();
            return View(listofData);
        }
        [HttpPost]
        public ActionResult InspectionList(string departmentsearch)
        {
            List<Inspection> inspections = (from o in context.Inspections as IEnumerable<Inspection>
                                            join d in context.Departments on o.DepartmentId equals d.DepartmentId
                                            where d.DepartmentName == departmentsearch
                                            select new Inspection
                                            {

                                                Review = o.Review,
                                                // Staff = o.Staff,
                                                Subject = o.Subject,
                                                Status = o.Status,
                                                InspectionId = o.InspectionId
                                            }).ToList();

            return View(inspections);

        }
      
        
       [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult UpdateInspectionDetails(int? id)
        {
            var Inspectiondata= context.Inspections.Where(x => x.InspectionId == id).FirstOrDefault();
            var Statuslist = new List<string>() { "Completed", "Pending", "In-Process" };
            ViewBag.Inspections = Statuslist;
            return View(Inspectiondata);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult UpdateInspectionDetails(Inspection Model)
        {
            var data = context.Inspections.Where(x => x.InspectionId == Model.InspectionId).FirstOrDefault();
            if (data != null)
            {
                data.InspectionId = Model.InspectionId;
                data.Subject = Model.Subject;
                data.Status = Model.Status;
                data.Review = Model.Review;
                data.DepartmentId = Model.DepartmentId;
                data.Frequency = Model.Frequency;
                data.InspectedDate = Model.InspectedDate;
                data.NextDueDate = Model.NextDueDate;

                context.SaveChanges();
            }
            return RedirectToAction("InspectionList");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteInspectionDetails()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInspectionDetails(int id)
        {
            var data = context.Inspections.FirstOrDefault(x => x.InspectionId == id);
            if (data != null)
            {
                context.Inspections.Remove(data);
                context.SaveChanges();
                return RedirectToAction("InspectionList");
            }
            else
                return View();
        }
        public ActionResult InspectionDetails(int id)
        {
            var data = context.Inspections.Where(x => x.InspectionId == id).FirstOrDefault();
            return View(data);
        }



    }
}
