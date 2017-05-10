﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class CashDisbursement
    {
        [Display(Name = "Check Number #")]
        public int CheckNumber { get; set; }

        [Display(Name = "Cash Account #")]
        public int CashAccountID { get; set; }

        [Display(Name = "CD Type #")]
        public int CDTypeID { get; set; }

        //VendorID
        /*[Display(Name = "Payee #")]
        public int PayeeID { get; set; }*/
        [Display(Name = "Payee #")]
        public int VendorID { get; set; }

        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        //Labor Acquisition
        [Display(Name = "Time Card #")]
        public int TimeCardID { get; set; }

        //InventoryREceiptID
        [Display(Name = "Event #")]
        public int InventoryReceiptID { get; set; }

        //cashdebursement amount
        [Display(Name = "Amount Paid")]
        public int CashDisbursementAmount { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime CashDisbursementDate { get; set; }

        // m-1 purchase cashaccount employee vendor
        public Purchase Purchase { get; set; }
        public CashAccount CashAccount { get; set; }
        public Employee Employee { get; set; }
        public Vendor Vendor { get; set; }
        public CashDisbursementType CashDisbursementType { get; set; }
        public LaborAcquisition LaborAcquisition { get; set; }
        //1-1 employee_1 FulfillmentLACD FulfillmentSSCD 
        public Employee_1 Employee_1 { get; set; }
        public FulfillmentLACD FulfillmentLACD { get; set; }
        public FulfillmentSSCD FulfillmentSSCD { get; set; }
    }
}