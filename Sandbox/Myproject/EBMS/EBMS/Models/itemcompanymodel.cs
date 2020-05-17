using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EBMS.Models
{
    public class itemcompanymodel
    {
       /* public int id { get; set; }
        public string item_company_id { get; set; }*/
        [Display(Name ="Item Company Name")]
        [Required(ErrorMessage ="Can't be blank.")]
        [RegularExpression("^([a-zA-Z0-9]+)$", ErrorMessage = "Invalid Company Name.")]
        [MinLength(2,ErrorMessage ="minimum 2 character required.")]
        [MaxLength(27,ErrorMessage ="item company name cannot be greater than 27.")]
        public string item_company_name { get; set; }
    }
}