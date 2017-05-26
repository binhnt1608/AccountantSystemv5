using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class OutflowSaleInventory
    {
        [Key]
        [Display(Name = "Sale Order #")]
        public int InvoiceID { get; set; }

        [Display(Name = "Item #")]
        public int InventoryID { get; set; }

        [Display(Name = "Quatity ")]
        public int QuantityOrdered { get; set; }

        [Display(Name = "Price")]
        public int SOPrice { get; set; }

        //m=1 Sale Inventory
        public virtual Sale Sale { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
