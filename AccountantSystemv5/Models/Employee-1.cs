using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Employee_1
    {
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        public string EmployeeLastName { get; set; }

        public string EmployeeFristName { get; set; }

        public string EmployeeMiddleInitial { get; set; }

        // cashdisbursement 1-1
        public CashDisbursement CashDisBursement { get; set; }
        //1-m labor acquisition
        public ICollection<LaborAcquisition> LaborAcquisition { get; set; }
    }
}
