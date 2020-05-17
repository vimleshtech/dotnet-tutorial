using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBMS.Models;
using System.IO;

namespace EBMS.Controllers
{
    public class item_informationController : Controller
    {
        
        common objcommon = new common();

        public  ActionResult Add_Item()
        {

            ViewBag.generate_barcode = "true";
            if (objcommon.fill_item_unit().Count<=0)
            {
                return RedirectToAction("item_unit", "item_unit");
            }
            else
            {
                ViewBag.unit = objcommon.fill_item_unit();
                
            }

            if (objcommon.fill_item_company().Count<=0)
            {
               return RedirectToAction("item_company", "item_company");
            }
            else
            {
                ViewBag.company = objcommon.fill_item_company();     
            }


            if (objcommon.fill_item_group().Count <= 0)
            {
                return RedirectToAction("item_group", "item_group");
            }
            else
            {
                ViewBag.group = objcommon.fill_item_group();

            }

            if (objcommon.fill_item_tax().Count <= 0)
            {
                return RedirectToAction("item_group", "item_group");
            }
            else
            {
                ViewBag.tax = objcommon.fill_item_tax();
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult Add_Item(iteminformationmodel obj,string company_list,string group_list,
            string unit_list,string Generate_Barcode,string item_barcode,
            string print_name_chk,string item_print_name)
        {

            if (Generate_Barcode == "false")
            {
                ViewBag.generate_barcode = "false";
                ViewBag.item_barcode = item_barcode;
            }
            else
            {
                ViewBag.generate_barcode = "true";
            }
            if (print_name_chk == "true")
            {
                ViewBag.print_name_chk = true;
            }
            ViewBag.item_print_name = item_print_name;
      
            ViewBag.unit = objcommon.fill_item_unit();
            ViewBag.company = objcommon.fill_item_company();
            ViewBag.group = objcommon.fill_item_group();

            ViewBag.print_name_chk = print_name_chk;
            if (ModelState.IsValid)
            {

                obj.item_company_name = company_list;
                obj.item_group_name = group_list;
                obj.item_unit_name = unit_list;

                objcommon.add_new_item_information(obj);
            }
            return View();
        }

        public ActionResult Item_list()
        {
            return View();
        }

        public ActionResult Edit_Item()
        {
            return View();
        }
       
    }
}