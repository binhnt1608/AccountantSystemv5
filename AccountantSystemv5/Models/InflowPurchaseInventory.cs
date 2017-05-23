using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class InflowPurchaseInventory
    {
        [Key]
        [Display(Name = "Inventory Receipt #")]
        public int InventoryReceiptID { get; set; }

        [Display(Name = "Item #")]
        public int InventoryID { get; set; }

        [Display(Name = "Quantity")]
        public int QuantityReceived { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public int InventoryReceiptPrice { get; set; }


        //m-1 Inventory Purchase
        public virtual Inventory Inventory { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
