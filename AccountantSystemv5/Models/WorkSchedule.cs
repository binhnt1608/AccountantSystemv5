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
            ReservationWSLTs = new HashSet<ReservationWSLT>();

            FulfillmentWSLAs = new HashSet<FulfillmentWSLA>();

        }

        [Display(Name = "Work Schedule #")]
        public int ScheduleID { get; set; }

        //1-m FulfillmentWSLA ReservationWSLT

        public ICollection<FulfillmentWSLA> FulfillmentWSLAs { get; set; }

        public ICollection<ReservationWSLT> ReservationWSLTs { get; set; }
    }
}
