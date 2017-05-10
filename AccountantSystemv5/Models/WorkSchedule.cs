using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class WorkSchedule
    {
        public WorkSchedule()
        {
        }

        [Display(Name = "Work Schedule #")]
        public int ScheduleID { get; set; }

        //Dat > 
        // WorkSchedule vs LaborType
        public List<FulfillmentWSLA> FulfillmentWSLAs { get; set; }

        // Work Schedule vs LaborType
        public List<ReservationWSLT> ReservationWSLTs { get; set; }

        // Work Schedule vs Employee
        public List<ExternalPartWSE> ExternalPartWSEs { get; set; }

        //Dat <
    }
}
