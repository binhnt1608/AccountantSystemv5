using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class ReservationSaleOrderInventory
    {
        [Display(Name = "Sale Order #")]
        public int SaleOrderID { get; set; }

        [Display(Name = "Item #")]
        public int InventoryID { get; set; }

        [Display(Name = "Quatity ")]
        public int QuantityOrdered { get; set; }

        [Display(Name = "Price")]
        public int SOPrice { get; set; }

        //m-1 saleorder inventory
        public virtual SaleOrder SaleOrder{ get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
