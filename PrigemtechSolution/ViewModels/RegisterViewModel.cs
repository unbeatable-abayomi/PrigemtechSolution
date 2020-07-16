using Microsoft.AspNetCore.Mvc;
using PrigemtechSolution.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrigemtechSolution.ViewModels
{
    public class RegisterViewModel
    {  
        [Required]
       [EmailAddress]
       [Remote(action: "IsEmailInUse", controller:"account")]
       //[ValidEmailDomain(allowedDomain : "pragimtech.com", ErrorMessage = "Email Doamin Must be pragimtech.com ")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confrimation password don't match")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}
