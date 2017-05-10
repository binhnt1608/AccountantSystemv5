using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Inventory
    {
        public Inventory() { }

        [Required]
        [Display(Name = "Inventory #")]
        public int InventoryID { get; set; }


        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
        public string InventoryDescription { get; set; }

        [Display(Name = "Composition")]
        public int InventoryCompositionID { get; set; }

        [Display(Name = "Type")]
        public int InventoryTypeID { get; set; }

        [Display(Name = "Diameter")]
        public int InventoryDiameterID { get; set; }

        [Required]
        [Range(0, 10000)]
        [Display(Name = "List Price")]
        public string InventoryListPrice { get; set; }

        //m-1 composition type diameter
        public InventoryComposition InventoryComposition { get; set; }

        public InventoryType InventoryType { get; set; }

        public InventoryDiameter InventoryDiameter { get; set; }

        //Dat
        // Inventory vs Sale Order
        public List<ReservationSaleOrderInventory> ReservationSaleOrderInventories { get; set; }

        // Inventory vs Sale
        public List<OutflowSaleInventory> OutflowSaleInventories { get; set; }

        // Inventory vs Purchase Order
        public List<ReservationPurchaseOrderInventory> ReservationPurchaseOrderInventories { get; set; }

        // Inventory vs Purchase
        public List<InflowPurchaseInventory> InflowPurchaseInventories { get; set; }




    }
}
