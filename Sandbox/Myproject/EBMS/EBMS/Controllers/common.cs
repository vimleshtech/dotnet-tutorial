using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EBMS.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

namespace EBMS.Controllers
{
   
    public class common
    {

        SqlConnection con = null;

        private SqlConnection establishconnection() /////ESTABLISH SQL CONNECTION
        {            
            string constring = ConfigurationManager.AppSettings["dbconnection"].ToString();
            con = new SqlConnection(constring);
            con.Open();
            return con;
        }

        public void Add_material_centre_detail(item_material_centre obj1)
        {
           
            SqlCommand cmd = new SqlCommand("sp_add_material_centre", establishconnection());
           
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@material_centre_name", obj1.material_centre_name));
            cmd.Parameters.Add(new SqlParameter("@material_centre_type", obj1.material_centre_type));
            cmd.Parameters.Add(new SqlParameter("@material_centre_address", obj1.material_centre_address));

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            
        }
        public Boolean checkuser(string usr_name,string pasword)  /////CHECK USER EXIST IN DATABSE OR NOT
        {
           var rdsd= HttpContext.Current.Session["CAPTCHA"].ToString();

            var res = (from x in objentities.userlogins
                      where x.user_name1 == usr_name 
                      && x.user_password == pasword
                      select x).FirstOrDefault();

            if(res==null)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        public Boolean session_expire()
        {
            if (HttpContext.Current.Session["user_active"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean user_status()
        {                      

            if (HttpContext.Current.Session["user_active"] != null)
            {
                var uuyg = HttpContext.Current.Session["user_active"].ToString();
                var res = (from x in objentities.userlogins
                           where x.user_name1 == uuyg
                           select x).FirstOrDefault();

                if (res == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
           
        }
        
        public string getrandomtext()   ////GET RANDOM TEXT 
        {
          
            StringBuilder randomtext = new StringBuilder();

            string text = "012345679ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz";
            Random r = new Random();
            for(int i = 0; i <= 4; i++)
            {
                randomtext.Append(text[r.Next(text.Length)]);
            }
            
            return randomtext.ToString();
        }
        public string read_article_no()   ///READ ARTICLE NUMBER FROM DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            string result = temp.article_no.ToString();
            return result;
        }
        public string read_barcode()      ////READ BARCODE FRORM DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            string result = temp.barcode.ToString();
            return result;
        }
        public void add_new_item_information(iteminformationmodel obj1)   //// ADD ITEM INFINFORMATION IN DATABASE
        {
            item_information obj2 = new item_information();

            if (obj1.item_barcode == null)
            {
                string barcode = read_barcode();
                obj2.item_barcode = barcode;   ////   ITEM BARCODE
            }
            else
            {
                obj2.item_barcode = obj1.item_barcode;    ////   ITEM BARCODEs
            }
            obj2.item_article_no = read_article_no();
            obj2.item_name = obj1.item_name;                       ////    ITEM NAME
            obj2.item_print_name = obj1.item_print_name;           ////    ITEM PRINT NAME
            obj2.item_group_name = obj1.item_group_name;           ////    ITEM GROUP NAME
            obj2.item_company_name = obj1.item_company_name;       ////    ITEM COMPANY NAME
            obj2.item_unit_name = obj1.item_unit_name;             ////    ITEM UNIT NAME
            obj2.item_CGST = obj1.item_CGST;                       ////    ITEM CGST
            obj2.item_SGST = obj1.item_SGST;                       ////    ITEM SGST
            obj2.item_IGST = obj1.item_IGST;                       ////    ITEM IGST   
            obj2.item_MRP = obj1.item_MRP;                         ////    ITEM MRP
            obj2.item_purchase_price = obj1.item_purchase_price;   ////    ITEM PURCHASE PRICE
            obj2.item_sale_price = obj2.item_sale_price;           ////    ITEM SALE PRICE
            obj2.item_previous_stock = obj1.item_previous_stock;   ////    ITEM PREVIOUS STOCK
            obj2.item_stock_amount = obj1.item_stock_amount;       ////    ITEM STOCK AMOUNT
            obj2.item_description = obj1.item_description;         ////    ITEM DESCRIPTION
            obj2.item_maxlevel_qty = obj1.item_maxlevel_qty;       ////    ITEM MAX LEVEL QUANTITY
            obj2.item_minlevel_qty = obj1.item_minlevel_qty;       ////    ITEM MIN LEVEL QUANTITY
            obj2.img = obj1.img;                                   ////    ITEM IMAGE



            if (obj1.item_barcode == null)
            {
                string barcode = read_barcode();
                obj1.item_barcode = barcode;
            }
           /* SqlCommand cmd = new SqlCommand("sp_add_item_information", establishconnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@item_id", obj2.item_id);
            cmd.Parameters.AddWithValue("@item_barcode", obj2.item_barcode);
            cmd.Parameters.AddWithValue("@item_article_no", obj2.item_article_no);
            cmd.Parameters.AddWithValue("@item_name", obj2.item_name);
            cmd.Parameters.AddWithValue("@item_print_name", obj2.item_print_name);
            cmd.Parameters.AddWithValue("@item_group_name", obj2.item_group_name);
            cmd.Parameters.AddWithValue("@item_company_name", obj2.item_company_name);
            cmd.Parameters.AddWithValue("@item_unit_name", obj2.item_unit_name);
            cmd.Parameters.AddWithValue("@item_CGST", obj2.item_CGST);
            cmd.Parameters.AddWithValue("@item_SGST", obj2.item_SGST);
            cmd.Parameters.AddWithValue("@item_IGST", obj2.item_IGST);
            cmd.Parameters.AddWithValue("@item_MRP", obj2.item_MRP);
            cmd.Parameters.AddWithValue("@item_purchase_price", obj2.item_purchase_price);
            cmd.Parameters.AddWithValue("@item_sale_price", obj2.item_sale_price);
            cmd.Parameters.AddWithValue("@item_previous_stock", obj2.item_previous_stock);
            cmd.Parameters.AddWithValue("@item_stock_amount", obj2.item_stock_amount);
            cmd.Parameters.AddWithValue("@item_description", obj2.item_description);
            cmd.Parameters.AddWithValue("@item_maxlevel_qty", obj2.item_maxlevel_qty);
            cmd.Parameters.AddWithValue("@item_minlevel_qty", obj2.item_minlevel_qty);
            cmd.Parameters.AddWithValue("@img", obj2.img);*/
           
        }

        ebmsEntities objentities = new ebmsEntities();  /// object of entities
        public string read_item_company_code() /// READ ITEM COMPANY CODE FROM DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            string item_com_code = "ICC-" + temp.company_id;
            return item_com_code;
        }

        public void update_item_company_code()  ///UPDATE ITEM COMPANY CODE IN DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            temp.company_id  = temp.company_id  + 1;
            objentities.SaveChanges();
        }

        public string check_duplicate_company_record(string name) ////CHECK DUPLICATE ITEM COMPANY NAME RECORD FOUND IN DATABASE
        {
            var temp = (from x in objentities.item_company where x.item_company_name == name select x).FirstOrDefault();

            if (temp == null)
            {
                return "true";
            }
            else
            {
                return "false";
            }

        }
        public List< item_company> fill_item_company() /////FILL ITEM COMPANY LIST
        {
            List<item_company> temp = (from x in objentities.item_company select x).ToList();
            return temp;
        }


        public string read_item_group_code()  ///READ ITEM GROUP CODE FROM DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            string item_gro_code = "IGC-" + temp.group_id;
            return item_gro_code;
        }

        public void update_item_group_code()   ///UPDATE ITEM GROUP CODE IN DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            temp.group_id = temp.group_id+1;
            objentities.SaveChanges();
        }

        public List<item_group> fill_item_group() /////FILL ITEM GROUP LIST
        {
            List<item_group> temp = (from x in objentities.item_group select x).ToList();
            return temp;

        }
        public string read_item_unit_code()  ///READ ITEM UNIT CODE FROM DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            string item_uni_code = "IUC" + temp.unit_id;
            return item_uni_code;
        }

        public string read_state_code()    ///READ STATE CODE FROM DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            string state_code = "SC-" + temp.state_id;
            return state_code;

        }

        public Boolean check_state_exist(string state_code,string statename)   ////CHECK DUPLICATE STATE IN DATABASE
        {
            var res = (from x in objentities.state_list
                       where x.state_code == state_code ||
                       x.state_name == statename
                       select x).FirstOrDefault();
                       
            if(res==null)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }
        public void update_statelist_code()  ///UPDATE STATE CODE IN DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            temp.state_id = temp.state_id + 1;
            objentities.SaveChanges();
        }
        public void update_item_unit_code()   ///UPDATE ITEM UNIT CODE IN DATABASE
        {
            code temp = (from x in objentities.codes select x).FirstOrDefault();
            temp.unit_id = temp.unit_id + 1;
            objentities.SaveChanges();
        }

        public string check_duplicate_unit_record(string name) ////CHECK DUPLICATE ITEM UNIT RECORD FOUND IN DATABASE
        {
            var temp = (from x in objentities.item_unit where x.item_unit_name == name select x).FirstOrDefault();

            if(temp==null)
            {
                return "true";
            }
            else
            {
                return "false";
            }
            
        }
       
        public List<item_unit> fill_item_unit()   /////FILL UNIT LIST
        {
            List<item_unit> temp = (from x in objentities.item_unit select x).ToList();
            return temp;
        }

        public List<Item_tax> fill_item_tax()     /////FILL ITEM TAX
        {
            List<Item_tax> temp = (from x in objentities.Item_tax select x).ToList();
            return temp;
        }
    }
}