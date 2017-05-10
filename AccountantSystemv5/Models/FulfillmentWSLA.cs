using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class FulfillmentWSLA
    {
        [Display(Name = "Schedule #")]
        public int ScheduleID { get; set; }

        [Display(Name = "Time Card #")]
        public int TimeCardID { get; set; }

        //m-1
        public LaborAcquisition LaborAcquisition { get; set; }

        public WorkSchedule WorkSchedule { get; set; }
    }
}
