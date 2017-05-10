﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class OutflowSaleInventory
    {
        [Display(Name = "Sale Order #")]
        public int InvoiceID { get; set; }

        [Display(Name = "Item #")]
        public int InventoryID { get; set; }

        [Display(Name = "Quatity ")]
        public int QuantityOrdered { get; set; }

        [Display(Name = "Price")]
        public int SOPrice { get; set; }

        //m=1
        public Sale Sale { get; set; }

        public Inventory Inventory { get; set; }
    }
}