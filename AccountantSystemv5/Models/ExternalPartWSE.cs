using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class ExternalPartWSE
    {
        [Display(Name = "Schedule #")]
        public int ScheduleID { get; set; }

        [Display(Name = "EmployeeID-Admin #")]
        public int EmployeeID { get; set; }

        //m-1 employee withholding
        public Employee Employee { get; set; }
        public WorkSchedule Schedule { get; set; }
    }
}
