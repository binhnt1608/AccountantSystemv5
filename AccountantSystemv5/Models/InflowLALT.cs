using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class InflowLALT
    {
        [Key]
        public int TimeCardID { get; set; }

        public int LaborTypeID { get; set; }

        //m-1 LaborType LaborAcquisition
        public virtual LaborType LaborType { get; set; }

        public virtual LaborAcquisition LaborAcquisition { get; set; }
    }
}
