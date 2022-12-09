using AirportMaintenanceSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMaintenanceSystemProject.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        
            public ActionResult ItemList()
            {
            AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
            List<Item> items = context.Items.ToList();
                return View(items);

            }
        public ActionResult InventoryDetails(int? id)
        {
            AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();
            List<Inventory> inventories = context.Inventories.Where(s => s.ItemId == id).ToList();
            return View(inventories);

        }

       }
    }
