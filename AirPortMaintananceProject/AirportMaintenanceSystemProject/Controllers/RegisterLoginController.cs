 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AirportMaintenanceSystemProject.Models;

namespace AirportMaintenanceSystemProject.Controllers
{
    public class RegisterLoginController : Controller
    {
        AirportMaintenanceSystemEntities context = new AirportMaintenanceSystemEntities();



        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserLoginRegister userRegister)
        {
            if (ModelState.IsValid)
            {
                context.UserLoginRegisters.Add(userRegister);
                if (context.SaveChanges() > 0)
                {

                    return RedirectToAction("Login");
                }
            }

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]


        
        public ActionResult Login(UserLoginRegister userLogin, string ReturnUrl)
        {
           
                var user = context.UserLoginRegisters.Where(x => x.UserName == userLogin.UserName && x.Password == userLogin.Password).FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(userLogin.UserName, false);


                return RedirectToAction("Dashboard");
               
            }
                else
                {
                ViewData["SuccessMessage"] = "<script>alert('Invalid credential!')</script>";
               

            }
                return View();

            }
        
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return Redirect("Login");
        }


    }
}