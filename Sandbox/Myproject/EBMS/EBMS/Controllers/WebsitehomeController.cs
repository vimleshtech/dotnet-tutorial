using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBMS.Controllers
{
    public class WebsitehomeController : Controller
    {
        // GET: Websitehome
        public ActionResult webhome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult webhome(string Login)
        {
            return View();
        }
    }
}