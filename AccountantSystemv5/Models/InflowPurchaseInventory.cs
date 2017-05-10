using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class InflowPurchaseInventory
    {
        public int InventoryID { get; set; }
        public int InventoryReceiptID { get; set; }

        //m-1 Inventory Purchase
        public Inventory Inventory { get; set; }
        public Purchase Purchase { get; set; }
    }
}
