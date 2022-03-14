using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneShop.Models
{
    public class Customer
    {
        [Required]
        public string id { get; set; }
        [Required(ErrorMessage ="Name required")]
        [StringLength(100,ErrorMessage ="length should be between 4 to 20",MinimumLength =4)]
        public string username { get; set; }
        [Required(ErrorMessage = "Email required")]
        public string email { get; set; }
        [Required(ErrorMessage = "Mobile number required")]
        public string mobileno { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string password { get; set; }
    }
}