using AirportMaintenanceSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMaintenanceSystemProject.Controllers
{
    [Authorize]
    public class WorkScheduleController : Controller
    {
        AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
        // GET: ScheduleWork



        public ActionResult ListWorkSchedule()
        {
            var listofData = context.Operations.ToList();


            return View(listofData);

        }



        [HttpGet]
        public ActionResult ScheduleWorkToStaff()
        {
            var staffList = context.Staffs.ToList();
            ViewBag.StaffList = new SelectList(staffList, "StaffId", "StaffName");

            return View();
        }

        [HttpPost]
        public ActionResult ScheduleWorkToStaff(Operation model)
        {

            context.Operations.Add(model);
            context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("ScheduleWorkToStaff");
        }

        public ActionResult AssignTask()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignTask(int id)
        {
            var Assigndata = context.Operations.FirstOrDefault(x => x.OperationId == id);
            var staffid = Assigndata.StaffId;
            var subject = Assigndata.Subject;

            if (Assigndata != null)
            {
                var Assigndetails = context.Staffs.FirstOrDefault(x => x.StaffId == staffid);

                var staffname = Assigndetails.StaffName;
                AssignTask assigntask = new AssignTask();
                assigntask.Staff = staffname;
                assigntask.Task = subject;
                context.AssignTasks.Add(assigntask);
                context.Operations.Remove(Assigndata);
                context.SaveChanges();
                ViewBag.Message = "Task Assigned Successfully";
                return RedirectToAction("ListWorkSchedule");
            }
            else
                return View(Assigndata);
        }



    }
}








