using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Inventory
    {
        public Inventory()
        {
            InflowPurchaseInventory = new HashSet<InflowPurchaseInventory>();
            ReservationPurchaseOrderInventory = new HashSet<ReservationPurchaseOrderInventory>();
        }

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

        //// Inventory  1-m Inflow P-I
        public ICollection<InflowPurchaseInventory> InflowPurchaseInventory { get; set; }

        // Inventory 1-m Reservation PO-I
        public ICollection<ReservationPurchaseOrderInventory> ReservationPurchaseOrderInventory { get; set; }

        // Inventory 1-m Reservation SO-I
        public ICollection<ReservationSaleOrderInventory> ReservationSaleOrderInventory { get; set; }

        //outflow 1-m
        public ICollection<OutflowSaleInventory> OutflowSaleInventory { get; set; }
    }
}
