using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using EBMS.Models;


namespace EBMS.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        common objcommon = new  common();
        public ActionResult Dash()
        {

            Boolean re = objcommon.session_expire();
            if(re==false)
            {
                return RedirectToAction("Expired", "Session");
            }
            Boolean result = objcommon.user_status();

            if(result==false)
            {
                return RedirectToAction("Dash", "Dashboard");
            }
            return View();
        }
    }
}