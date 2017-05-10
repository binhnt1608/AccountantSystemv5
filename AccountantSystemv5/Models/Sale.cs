using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Sale
    {
        [Display(Name = "Invoce #")]
        public int InvoiceID { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime ShippingDate { get; set; }

        [Display(Name = "Customer #")]
        public int CustomerID { get; set; }

        [Display(Name = "Sale Order #")]
        public int SaleOrderID { get; set; }

        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Sale Amount")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public int SaleAmount { get; set; }

        //m-1
        public ICollection<SaleOrder> SaleOrder { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection<Employee> Employee { get; set; }

        // public SaleOrder SaleOrder { get; set; }
        //1-m cashreceipt OutflowSaleInventory
        public ICollection<CashReceipt> CashReceipt { get; set; }

        public ICollection<OutflowSaleInventory> OutflowSaleInventory { get; set; }
    }
}
