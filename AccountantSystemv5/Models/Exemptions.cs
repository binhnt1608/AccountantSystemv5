using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Exemptions
    {
        [Key]
        [Display(Name = "Exemption Number")]
        public int ExemptionNum { get; set; }

        [Display(Name = "Exemption Amount")]
        public int ExemptionAmount { get; set; }

        //1-m employee
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
