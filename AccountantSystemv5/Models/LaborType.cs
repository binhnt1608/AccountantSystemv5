using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class LaborType
    {
        public LaborType()
        {
        }

        [Display(Name = "Labor Type #")]
        public int LaborTypeID { get; set; }

        //1-m InflowLALT ReservantionWSLT
        public List<InflowLALT> InflowLALTs { get; set; }
        public List<ReservationWSLT> ReservationWSLTs { get; set; }
    }
}
