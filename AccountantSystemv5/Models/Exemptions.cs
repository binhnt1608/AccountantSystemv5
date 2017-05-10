using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Exemptions
    {
        [Display(Name = "Exemption Number")]
        public int ExemptionNum { get; set; }

        [Display(Name = "Exemption Amount")]
        public int ExemptionAmount { get; set; }

        //1-m
        public ICollection<Employee> Employee { get; set; }
    }
}
