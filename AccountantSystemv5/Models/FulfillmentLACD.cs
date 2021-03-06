﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class FulfillmentLACD
    {
        [Key]
        [Display(Name = "LoanPayment #")]
        public int LoanPaymentID { get; set; }

        [Required]
        [Display(Name = "Loan #")]
        public int LoanID { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDueDate { get; set; }

        [Display(Name = "Payment #")]
        public int PaymentNum { get; set; }

        [Display(Name = "Principal #")] 
        public int PrincipalAmount { get; set; }

        [Display(Name = "Interest")]
        public int InterestAmount { get; set; }

        //m-1 LoanArgeement
        public virtual LoanAgreement LoanAgreement { get; set; }

        //1-1 CashDisbursement
        public virtual ICollection<CashDisbursement> CashDisbursement { get; set; }
    }
}
