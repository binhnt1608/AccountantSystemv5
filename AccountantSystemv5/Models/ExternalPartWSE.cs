using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class ExternalPartWSE
    {
        [Key]
        [Display(Name = "Schedule #")]
        public int ScheduleID { get; set; }

        [Display(Name = "EmployeeID-Admin #")]
        public int EmployeeID { get; set; }

        //m-1 employee withholding
        public virtual Employee Employee { get; set; }
        public virtual WorkSchedule Schedule { get; set; }
    }
}
