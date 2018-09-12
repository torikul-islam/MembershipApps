using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MembershipApps.Models
{
    public class UserViewModel
    {
        [Display(Name = "User Id")]
        public string Id { get; set; }

        [Required, EmailAddress, DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("First Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {1} characters long."), MinLength(2)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}