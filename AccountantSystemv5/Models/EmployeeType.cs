using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class EmployeeType
    {
        [Display(Name = "Employee Type #")]
        public int EmployeeTypeID { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Employee type's name cannot be longer than 50 and at least 1 characters.")]

        public ICollection<Employee> Employee { get; set; }
    }
}
