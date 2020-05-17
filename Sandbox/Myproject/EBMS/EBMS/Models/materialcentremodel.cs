using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EBMS.Models
{
    public class materialcentremodel
    {
        public int id { get; set; }
        public string material_centre_id { get; set; }
        [Display(Name = "Material Centre Name")]
        [Required(ErrorMessage = "Can't be blank.")]
        [RegularExpression("^([a-zA-Z0-9]+)$", ErrorMessage = "Invalid Material Centre Name.")]
        [MinLength(2, ErrorMessage = "minimum 2 character required.")]
        [MaxLength(27, ErrorMessage = "Material Centre name cannot be greater than 27.")]

        public string material_centre_name { get; set; }

        [Display(Name = "Material Centre Address ")]
        [Required(ErrorMessage = "Can't be blank.")]
        public string material_centre_address { get; set; }

        [Display(Name = "Material Centre Type ")]
        [Required(ErrorMessage = "Can't be blank.")]
        public string material_centre_type { get; set; }
        
    }
}