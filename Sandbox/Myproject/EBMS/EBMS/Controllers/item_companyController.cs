using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBMS.Models;


namespace EBMS.Controllers
{
    public class item_companyController : Controller
    {

        // GET: item_company
        common objcommon = new common();
        
        public ActionResult item_company()
        {

            using (ebmsEntities abj = new ebmsEntities())
            {


                TempData["company_list"] = objcommon.fill_item_company();
            }

            return View();
        }

        [HttpPost ]
        public ActionResult item_company(itemcompanymodel  obj,string Add,string Delete)
        {
            if (ModelState.IsValid)
            {

                item_company oo = new item_company(); ////object of model

                oo.item_company_name = obj.item_company_name;


                using (ebmsEntities abj=new ebmsEntities())  ///object of entities
                {                                    
                    
                    if (!string.IsNullOrEmpty(Add))
                    {
                        string item_company_code = objcommon.read_item_company_code();

                        oo.item_company_id = item_company_code;
                        oo.item_company_name = obj.item_company_name;

                        abj.item_company.Add(oo);
                        abj.SaveChanges();

                        objcommon.update_item_company_code();
                       
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