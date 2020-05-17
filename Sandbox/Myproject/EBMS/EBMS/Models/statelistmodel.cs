using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EBMS.Models
{
    public class statelistmodel
    {
        public int id { get; set; }

        public string state_id { get; set; }

        [Display(Name = "State Code")]
        [Required(ErrorMessage = "Can't be blank.")]
       
        [MinLength(2, ErrorMessage = "minimum 2 character required.")]
        [MaxLength(27, ErrorMessage = "State code cannot be greater than 27.")]
        public string state_code { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Can't be blank.")]
        [RegularExpression("^([a-zA-Z0-9]+)$", ErrorMessage = "Invalid State Name.")]
        [MinLength(2, ErrorMessage = "minimum 2 character required.")]
        [MaxLength(45, ErrorMessage = "State name cannot be greater than 45.")]
        public string state_name { get; set; }
    }
}