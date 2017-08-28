using Monitor.Business;
using Monitor.Data;
using Monitor.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Monitor.UI.Controllers
{

    public class MonitorController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            var userId = Customers.Register(model.Name, model.Email, model.Password);
            Session["userID"] = userId;
            Session["UserName"] = model.Name;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            Customer user = null;
            user = Customers.Login(model.EMail, model.Password);

            if (user == null)
            {
                model.LoginErrorMessage = "Yanlış Email veya password girildi.";
                return View("Login", model);
            }
            else
            {
                Session["userID"] = user.ID;
                Session["UserName"] = user.Name;
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult LogOut()
        {
            var userId = Session["userID"];
            Session.Abandon();
            return RedirectToAction("Login", "Monitor");
        }

    }
}