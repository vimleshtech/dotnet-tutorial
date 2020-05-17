using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBMS.Models;

namespace EBMS.Controllers
{
    public class material_centreController : Controller
    {
        common objcommon = new common();
       
        public ActionResult material_centre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult material_centre( materialcentremodel obj,string Add)
        {
            if(ModelState.IsValid)
            {
                using(ebmsEntities abj=new ebmsEntities())
                {
                    item_material_centre oo = new item_material_centre();

                    oo.material_centre_name = obj.material_centre_name.ToString();
                    oo.material_centre_type = obj.material_centre_type.ToString();
                    oo.material_centre_address = obj.material_centre_address.ToString();

                    objcommon.Add_material_centre_detail(oo);

                    ViewBag.status = "Successfully Add";

                    ModelState.Clear();

                }

            }
            return View();
        }

        public ActionResult material_centre_list()
        {
            //try
            //{
                using (ebmsEntities abj = new ebmsEntities())
                {
                    List< item_material_centre> ob = (from x in abj.item_material_centre select x).ToList();

                    List<materialcentremodel> l = new List<materialcentremodel>();

                foreach(item_material_centre temp in ob)
                {
                    materialcentremodel t = new materialcentremodel();
                    t.material_centre_id = temp.material_centre_id;
                    t.material_centre_address = temp.material_centre_address;
                    t.material_centre_name = temp.material_centre_name;
                    t.material_centre_type = temp.material_centre_type;
                        
                    l.Add(t);

                }
               
                return View(l);
                }
           /* }
            catch(Exception ex)
            {
                Response.Write(ex);
            }

            return View();*/
        }
    }
}