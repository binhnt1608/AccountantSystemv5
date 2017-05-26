using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class ReservationWSLT
    {
        [Key]
        [Display(Name = "Schedule #")]
        public int ScheduleID { get; set; }

        [Display(Name = "Laber TYpe #")]
        public int LaborTypeID { get; set; }

        //m-1 workschedule labortype
        public virtual WorkSchedule WorkSchedule { get; set; }

        public virtual LaborType LaborType { get; set; }
    }
}
