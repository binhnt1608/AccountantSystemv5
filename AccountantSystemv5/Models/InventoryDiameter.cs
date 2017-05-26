using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class InventoryDiameter
    {
        [Key]
        [Display(Name = "Diameter #")]
        public int CompositionID { get; set; }

        [Display(Name = "Diameter Code")]
        public int InventoryDiameterCode { get; set; }

        [Display(Name = "Diameter Description")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Description cannot be longer than 50 and at least 1 characters.")]
        public string InventoryDiameterDescription { get; set; }

        //1-m inventory
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
