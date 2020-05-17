using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBMS.Models;

namespace EBMS.Controllers
{
    public class item_unitController : Controller
    {
        // GET: item_unit
        common objcommon = new common();

        public ActionResult item_unit()
        {
            /*if (objcommon.fill_item_unit().Count > 0)
            {
                ViewBag.isdata = true;

                ViewBag.unitlist = objcommon.fill_item_unit(); 
            }
            else
            {
                ViewBag.isdata = false;
            }
            */
            return View();
        }

        [HttpPost]
        public ActionResult item_unit(Itemunitmodel obj,string Add,string Delete,string data)
        {
            if(ModelState.IsValid)
            {
               /*  using (ebmsEntities abj = new ebmsEntities())
                {

                    if(!string.IsNullOrEmpty(Add))
                    {
                        item_unit oo = new item_unit();

                        string unit_code = objcommon.read_item_unit_code();

                        oo.item_unit_id = unit_code;
                        oo.item_unit_name = obj.item_unit_name;

                        string result = objcommon.check_duplicate_unit_record(obj.item_unit_name);

                        if (result == "true")
                        {
                            abj.item_unit.Add(oo);
                            abj.SaveChanges();  //// ADD ITEM UNIT RECORD 

                            objcommon.update_item_unit_code();  //// UPDATE ITEM UNIT CODE
                        }
                        else
                        {
                            Response.Write("Duplicate Record found!!!!!!!!!!!!!");
                        }
                        

                        TempData["data"] = objcommon.fill_item_unit();

                        ModelState.Clear();
                    }
                    if(!string.IsNullOrEmpty(Delete))
                    {
                        TempData["data"] = objcommon.fill_item_unit();
                    }
                }*/
            }
            return View();
        }
    }
}