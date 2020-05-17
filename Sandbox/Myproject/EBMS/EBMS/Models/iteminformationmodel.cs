using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.Web;
namespace EBMS.Models
{
   
    public class iteminformationmodel
    {
        public int id { get; set; }
        public string item_id { get; set; }

        [Display(Name ="ITEM BARCODE")]
        
        [MaxLength(28,ErrorMessage ="Barcode length can't be greator than 28")]
        [MinLength(6,ErrorMessage ="Minimum 6 character required")]
        public string item_barcode { get; set; }


        [Display(Name = "ITEM ARTICLE NO")]
        public string item_article_no { get; set; }


        [Display(Name = "ITEM NAME")]
        [Required(ErrorMessage = "Can't be blank.")]
        [MinLength(2, ErrorMessage = "minimum 2 character required.")]
        [MaxLength(37, ErrorMessage = "item name cannot be greater than 37.")]
        public string item_name { get; set; }


        [Display(Name = "ITEM PRINT NAME")]
        [Required(ErrorMessage = "Can't be blank.")]
        [MinLength(2, ErrorMessage = "minimum 2 character required.")]
        [MaxLength(37, ErrorMessage = "item print name cannot be greater than 37.")]
        public string item_print_name { get; set; }

        
        [Display(Name = "ITEM GROUP")]
        public string item_group_name { get; set; }
        [Display(Name = "ITEM COMPANY")]
        public string item_company_name { get; set; }
        [Display(Name = "ITEM UNIT")]
        public string item_unit_name { get; set; }
        [Display(Name = "ITEM CGST")]
        public Nullable<decimal> item_CGST { get; set; }
        [Display(Name = "ITEM SGST")]
        public Nullable<decimal> item_SGST { get; set; }
        [Display(Name = "ITEM IGST")]
        public Nullable<decimal> item_IGST { get; set; }
        [Required(ErrorMessage = "Can't be blank.")]
        [Display(Name = "ITEM MRP")]
        [RegularExpression(@"^\d+.\d{0,3}$", ErrorMessage = "Price can't have more than 2 decimal places")]
        public Nullable<decimal> item_MRP { get; set; }

        


        private decimal? _item_purchase_price = 100;

        [Required(ErrorMessage = "Can't be blank.")]
        [Display(Name = "ITEM PURCHASE PRICE")]
        public Nullable<decimal> item_purchase_price { get; set; }
        [Required(ErrorMessage = "Can't be blank.")]
        [Display(Name = "ITEM SALE PRICE")]
        public Nullable<decimal> item_sale_price { get; set; }
        [Display(Name = "ITEM PREVOIUS STOCK")]
        public Nullable<decimal> item_previous_stock { get; set; }
        [Display(Name = "STOCK AMOUNT")]
        public Nullable<decimal> item_stock_amount { get; set; }
        [Display(Name = "ITEM DESCRIPTION")]
        public string item_description { get; set; }
        [Display(Name = "MAX LEVEL QTY")]
        public Nullable<decimal> item_maxlevel_qty { get; set; }
        [Display(Name = "MIN LEVEL QTY")]
        public Nullable<decimal> item_minlevel_qty { get; set; }
        [Display(Name = "ITEM BARCODE")]
        public byte[] img { get; set; }

       /* [Display(Name = "ITEM IMAGE")]
        public Nullable<bool> item_block { get; set; }*/
        
        [Display(Name = "ITEM BARCODE")]
        public Nullable<bool> item_deleted { get; set; }
    }
}