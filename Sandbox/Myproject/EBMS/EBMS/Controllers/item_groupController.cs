using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBMS.Models;

namespace EBMS.Controllers
{
    public class item_groupController : Controller
    {
        // GET: item_group

        common objcommon = new common();

        public ActionResult item_group()
        {
            return View();
        }

        [HttpPost]
        public ActionResult item_group( itemgroupmodel obj,string Add,string Delete)
        {
            if(ModelState.IsValid)
            {
                using (ebmsEntities abj = new ebmsEntities())
                {

                    if(!string.IsNullOrEmpty(Add))
                    {
                        item_group oo = new item_group();

                        string item_group_code = objcommon.read_item_group_code();

                        oo.item_group_id = item_group_code;
                        oo.item_group_name= obj.item_group_name;

                        abj.item_group.Add(oo);
                        abj.SaveChanges();  //// ADD ITEM COMPANY RECORD 

                        objcommon.update_item_group_code();   //// UPDATE ITEM COMPANY CODE

                        ModelState.Clear();

                    }
                    if(!string.IsNullOrEmpty(Delete))
                    {

                    }
                }
            }

            return View();
        }
    }
}