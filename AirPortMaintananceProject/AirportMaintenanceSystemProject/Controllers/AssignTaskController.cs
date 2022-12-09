using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportMaintenanceSystemProject.Models;

namespace AirportMaintenanceSystemProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AssignTaskController : Controller
    {
        AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
        // GET: AssignTask
        public ActionResult AssignTaskList()
        {
            var listofData = context.AssignTasks.ToList();

            return View(listofData);
        }
    }
}



