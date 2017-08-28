using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Monitor.Business;
using Monitor.UI.Models;
using Monitor.Data;

namespace Monitor.UI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestInsert(TestAddModel test)
        {
            Guid customerId = (System.Guid)Session["userID"];
            Business.Test.TestInsert(customerId, test.TestName, test.Url);
            //return View(test);
            return RedirectToAction("TestList", "Home");
        }

        public ActionResult TestList()
        {
            Guid customerId = (Guid)Session["userID"];
            return View(Business.Test.TestList(customerId));
        }

        public ActionResult SessionLog(Guid id)
        {
            return View(Business.Test.TestLogList(id));
        }


        public ActionResult UrunSil(Guid id)
        {
            Business.Test.TestRemove(id);
            return RedirectToAction("TestList");
        }

    }
}