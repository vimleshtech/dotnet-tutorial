using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EBMS.Models
{
    public class itemgroupmodel
    {
        /*public int id { get; set; }
        public string item_group_id { get; set; }*/

        [Display(Name = "Item Group Name")]
        [Required(ErrorMessage = "Can't be blank.")]
        [RegularExpression("^([a-zA-Z0-9]+)$", ErrorMessage = "Invalid Group Name.")]
        [MinLength(2, ErrorMessage = "minimum 2 character required.")]
        [MaxLength(27, ErrorMessage = "item group name cannot be greater than 27.")]
        public string item_group_name { get; set; }
    }
}