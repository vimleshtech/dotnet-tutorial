using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EBMS.Models
{
    public class Itemunitmodel
    {
        /* public int id { get; set; }
         public string item_unit_id { get; set; }*/
        [Display(Name = "Item Unit Name")]
        [Required(ErrorMessage = "Can't be blank.")]
        [RegularExpression("^([a-zA-Z0-9]+)$", ErrorMessage = "Invalid Unit Name.")]
        [MinLength(2, ErrorMessage = "minimum 2 character required.")]
        [MaxLength(27, ErrorMessage = "item unit name cannot be greater than 27.")]
        public string item_unit_name { get; set; }
    }
}