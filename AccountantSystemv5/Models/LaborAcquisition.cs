using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class LaborAcquisition
    {
        //public LaborAcquisition()
        //{
        //}

        [Display(Name = "Time Card #")]
        public int TimeCardID { get; set; }

        [Required]
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Supervisor #")]
        public int EmployeeSupervisorID { get; set; }

        [Required]
        [Display(Name = "Month Ended")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime LAPayPeriodEnded { get; set; }

        [Required]
        [Display(Name = "Regular Hours")]
        [Range(0, 184, ErrorMessage = "Please enter a number between 0 and 184.")]
        public int LARegularTime { get; set; }

        [Required]
        [Display(Name = "Overtime Hours")]
        [Range(0, 200, ErrorMessage = "Please enter a number between 0 and 200")]
        public int LAOvertime { get; set; }

        //1-1 CashDisbursement
        public virtual CashDisbursement CashDisbursement { get; set; }

        //m-1 employee employee1
        public virtual Employee Employee { get; set; }

        //public Employee_1 Employee_1 { get; set; }

        //Dat > 
        // labor type vs LA
        public ICollection<InflowLALT> InflowLALTs { get; set; }

        // LA-WSLA
        public ICollection<FulfillmentWSLA> FulfillmentWSLAs { get; set; }
    }
}
