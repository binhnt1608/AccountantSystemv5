using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Purchase
    {
        //public Purchase()
        //{
        //}

        [Key]
        [Display(Name = "Purchase #")]
        public int InventoryReceiptID { get; set; }

        [Display(Name = "Purchase Order #")]
        public int PurchaseOrderID { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Vendor")]
        public string VendorID { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Date Time is invalid")]
        public DateTime ReceivingReportDate { get; set; }

        [Display(Name = "Amount")]
        public int InventoryReceiptAmount { get; set; }

        [Required]
        [Display(Name = "Vendor Invoice ID")]
        public int ReceivingReportVendorInvoiceID { get; set; }
        
        //m-1 employee purchaseorder vendor
        public virtual Employee Employee { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Vendor Vendor { get; set; }
        
        //1-1 cashdisbursement
        public virtual CashDisbursement CashDisbursement { get; set; }

        //Dat >
        //Inventory vs Purchase
        public List<InflowPurchaseInventory> InflowPurchaseInventories { get; set; }
    }
}
