using AirportMaintenanceSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMaintenanceSystemProject.Controllers
{
    [Authorize]
    public class AirportItemController : Controller
    {

        AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
        // Action Method which will return the View containing list of Items
        public ActionResult ItemList()
        {
            var listofData = context.Items.ToList();
            return View(listofData);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddNewItem()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddNewItem(Item model)
        {
            context.Items.Add(model);
            context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult UpdateItemDetails(int? id)
        {
            var Itemdata = context.Items.Where(x => x.ItemId == id).FirstOrDefault();
            return View(Itemdata);
        }
        [HttpPost]
        public ActionResult UpdateItemDetails(Item Model)
        {
            var Itemdata = context.Items.Where(x => x.ItemId == Model.ItemId).FirstOrDefault();
            if (Itemdata != null)
            {
                Itemdata.ItemId = Model.ItemId;
                Itemdata.ItemName = Model.ItemName;
                Itemdata.ItemCost = Model.ItemCost;

                context.SaveChanges();
            }
            return RedirectToAction("ItemList");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemDetails(int id)
        {
            var Itemdata = context.Items.FirstOrDefault(x => x.ItemId == id);
            if (Itemdata != null)
            {
                context.Items.Remove(Itemdata);
                context.SaveChanges();
                return RedirectToAction("ItemList");
            }
            else
                return View();
        }
        public ActionResult ItemDetails(int id)
        {
            var Itemdata = context.Items.Where(x => x.ItemId == id).FirstOrDefault();
            return View(Itemdata);
        }




    }
}

