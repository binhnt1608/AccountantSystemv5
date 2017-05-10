using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class CashReceipt
    {
        [Display(Name = "RA #")]
        public int RemittanceAdviceID { get; set; }

        [Required]
        [Display(Name = "Cash Account #")]
        public int CashAccountID { get; set; }

        [Required]
        [Display(Name = "CR Type #")]
        public int CRTypeID { get; set; }

        [Required]
        [Display(Name = "Cash Receipt Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime CashReceiptDate { get; set; }

        [Required]
        [Display(Name = "Amount Received")]
        public int CasheReceiptAmount { get; set; }

        [Required]
        [Display(Name = "Payor Check #")]
        public int PayorCheckNum { get; set; }

        //Invoice-sale
        [Required]
        [Display(Name = "Event #")]
        public int InvoiceID { get; set; }


        //customer
        [Required]
        [Display(Name = "Payor #")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        //m-1  sale cashaccount customer employee
        public Sale Sale { get; set; }
        public CashAccount CashAccount { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public CashReceiptType CashReceiptType { get; set; }
        //1-1 stockSubscription LoanAgreement
        public StockSubscription StockSubscription { get; set; }
        public LoanAgreement LoanAgreement { get; set; }
    }
}
