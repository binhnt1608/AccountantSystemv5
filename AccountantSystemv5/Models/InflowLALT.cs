using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class InflowLALT
    {
        public int TimeCardID { get; set; }

        public int LaborTypeID { get; set; }

        //m-1 LaborType LaborAcquisition
        public LaborType LaborType { get; set; }

        public LaborAcquisition LaborAcquisition { get; set; }
    }
}
