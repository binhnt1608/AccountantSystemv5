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
            ReservationWSLTs = new HashSet<ReservationWSLT>();
            InflowLALTs = new HashSet<InflowLALT>();
        }

        [Display(Name = "Labor Type #")]
        public int LaborTypeID { get; set; }

        //1-m InflowLALT ReservantionWSLT
        public ICollection<InflowLALT> InflowLALTs { get; set; }
        public ICollection<ReservationWSLT> ReservationWSLTs { get; set; }
    }
}
