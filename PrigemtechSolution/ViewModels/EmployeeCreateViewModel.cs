using Microsoft.AspNetCore.Http;
using PrigemtechSolution.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrigemtechSolution.ViewModels
{
    public class EmployeeCreateViewModel
    {
      
        [Required]
        [MaxLength(50, ErrorMessage = "Name Cannot exceed 50 charaters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Deparment { get; set; }
        public IFormFile Photo { get; set; }
        //public List<IFormFile> Photos { get; set; }
    }
}
