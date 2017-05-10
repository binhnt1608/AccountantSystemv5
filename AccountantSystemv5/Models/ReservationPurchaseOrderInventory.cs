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

        [Display(Name = "Inventory #")]
        public int InventoryID { get; set; }

        //m-1 purchaseorder inventory
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
