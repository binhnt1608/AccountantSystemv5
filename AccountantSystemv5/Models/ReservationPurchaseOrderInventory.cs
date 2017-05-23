using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class ReservationPurchaseOrderInventory
    {

        [Display(Name = "Purchase Order #")]
        public int PurchaseOrderID { get; set; }

        [Display(Name = "Item #")]
        public int InventoryID { get; set; }

        [Display(Name = "Quantity")]
        public int QuantityOrdered { get; set; }

        [Display(Name = "Price")]
        public int POPrice { get; set; }

        [Display(Name = "Vendor Item #")]
        public int VendorItemID { get; set; }

        //m-1 purchaseorder inventory
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
