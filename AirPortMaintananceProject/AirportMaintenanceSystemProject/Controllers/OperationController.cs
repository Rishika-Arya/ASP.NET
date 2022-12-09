using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AirportMaintenanceSystemProject.Models;

namespace AirportMaintenanceSystemProject.Controllers
{
    [Authorize]
    public class OperationController : Controller
    {
        AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
        // GET: Operations
        public ActionResult OperationList()
        {
            var listofData = context.Operations.ToList();
            return View(listofData);

        }
        [HttpPost]
        public ActionResult Search(string departmentsearch)
        {
            List<Operation> operations = (from o in context.Operations as IEnumerable<Operation>
                                          join d in context.Departments on o.DepartmentId equals d.DepartmentId
                                          where d.DepartmentName == departmentsearch
                                          select new Operation
                                          {

                                              Remarks = o.Remarks,
                                              // Staff = o.Staff,
                                              Subject = o.Subject,
                                              Status = o.Status,
                                              OperationId = o.OperationId
                                          }).ToList();

            return View(operations);

        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddNewOperation()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddNewOperation(Operation model)
        {
            context.Operations.Add(model);
            context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult UpdateOperation(int? id)
        {
            var data = context.Operations.Where(x => x.OperationId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult UpdateOperation(Operation Model)
        {
            var data = context.Operations.Where(x => x.OperationId == Model.OperationId).FirstOrDefault();
            if (data != null)
            {
                data.OperationId = Model.OperationId;
                data.Subject = Model.Subject;
                data.Status = Model.Status;
                data.Remarks = Model.Remarks;
                data.DepartmentId = Model.DepartmentId;
                data.StaffId = data.StaffId;

                context.SaveChanges();
            }
            return RedirectToAction("OperationList");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteOperation()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOperation(int id)
        {
            var data = context.Operations.FirstOrDefault(x => x.OperationId == id);
            if (data != null)
            {
                context.Operations.Remove(data);
                context.SaveChanges();
                return RedirectToAction("OperationList");
            }
            else
                return View();
        }
        public ActionResult OperationDetails(int id)
        {
            var data = context.Operations.Where(x => x.OperationId == id).FirstOrDefault();
            return View(data);
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
                return RedirectToAction("Index");
            }
            else
                return View(Assigndata);
        }






    }
}
