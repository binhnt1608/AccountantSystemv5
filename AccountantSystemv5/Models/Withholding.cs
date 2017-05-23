using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class Withholding
    {
        //public Withholding()
        //{
        //    InflowEmployeeWithholdings = new HashSet<InflowEmployeeWithholding>();
        //}
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Tax Bracket")]
        public int FWTBracket { get; set; }

        [Required]
        [Display(Name = "Lower Limit")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal FWTLowerLimit { get; set; }

        [Required]
        [Display(Name = "Upper Limit")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal FWTUpperLimit { get; set; }

        [Required]
        [Display(Name = "FWT Rate")]
        [DisplayFormat(DataFormatString = "{0:##.####%}")]
        public string FWTRate { get; set; }

        [Required]
        [Display(Name = "FWT Base Amt")]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal FWTBracketBaseAmt { get; set; }

        //// 1 - m Inflow E-W
        //public ICollection<InflowEmployeeWithholding> InflowEmployeeWithholdings { get; set; }
        //1-1
        public virtual Employee Employee { get; set; }
    }
}
