using AirportMaintenanceSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMaintenanceSystemProject.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
        public ActionResult DepartmentList()
        {
            var listofData = context.Departments.ToList();
            return View(listofData);

        }

        public ActionResult StaffList()
        {
            var listofData = context.Staffs.ToList();
            return View(listofData);

        }
        public ActionResult AddStaff()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddStaff(Staff model)
        {
            context.Staffs.Add(model);
            context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        public ActionResult AirportServices()
        {
            return View();
        }
    }
}