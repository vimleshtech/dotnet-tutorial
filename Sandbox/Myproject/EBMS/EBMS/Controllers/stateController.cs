using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBMS.Models;

namespace EBMS.Controllers
{
    public class stateController : Controller
    {

        common objcommon = new common();

        public ActionResult state()
        {
            return View();
        }

        [HttpPost]
        public ActionResult state(statelistmodel obj,string Add,string Delete)
        {
            if (ModelState.IsValid)
            {
                using (ebmsEntities abj=new ebmsEntities())
                {
                    state_list oo = new state_list();

                    oo.state_code = obj.state_code.ToString();
                    oo.state_name = obj.state_name.ToString();

                    string state_code = objcommon.read_state_code();

                    oo.state_id = state_code.ToString();

                    bool res = objcommon.check_state_exist(oo.state_code, oo.state_name);

                    if(res==false)
                    {
                        abj.state_list.Add(oo);

                        abj.SaveChanges();

                        objcommon.update_statelist_code();


                        ViewBag.message = "Record Saved Successfully!!!!!";

                        ModelState.Clear();

                    }
                    else
                    {
                        ViewBag.message = "Duplicate Recod Found!!!!!";
                    }
                   
                }
            }

            return View();
        }

        public ActionResult state_list()
        {
            using (ebmsEntities o=new ebmsEntities())
            {
                var obj = (from x in o.state_list select x).ToList();

                return View(obj);
            }
            
        }
        [HttpPost]
        public ActionResult state_list(string id)
        {
            return View();
        }
    }
}