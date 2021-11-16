using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace CommanLayer.models
{
   public class Employee
    {
        public int Id { get; set; }
        [Display(Name ="Enter Employee Name")]
        [Required(ErrorMessage ="Employee Name required !")]
        public string Name { get; set; }

        [Display(Name = "Enter Employee Email")]
        [Required(ErrorMessage = "Employee email required !")]
     //   [EmailAddress(ErrorMessage ="Invalid Email Address")]
     [RegularExpression(pattern: "[^@ \t\r\n]+@[^@ \t\r\n]+\\.[^@ \t\r\n]+",ErrorMessage ="Invalid email address format!")]
        public string Email { get; set; }

        [Display(Name = "Enter Employee Salary")]
        [Required(ErrorMessage = "Employee salary required !")]
        public decimal Salary { get; set; }

    }
}
