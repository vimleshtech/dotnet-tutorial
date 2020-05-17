using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBMS.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Expired()
        {
            return View();
        }
    }
}