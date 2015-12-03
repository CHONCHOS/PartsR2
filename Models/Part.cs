using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartsR2.Models
{
    public class Part
    {
        [Key]
        public int PartID { get; set; }

        [Required]
        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Desc { get; set; }

        [Display(Name = "Condition Available")]
        public string CondAvail { get; set; }

        [Display(Name = "Quantity Available")]
        public string QtyAvail { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Exchange Price")]
        public decimal Exchange { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Core Price")]
        public decimal CorePrice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Outright Price")]
        public decimal OutrightPrice { get; set; }

        [Display(Name = "Certifications")]
        public string Certs { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "JJ Remarks")]
        public string JJRemarks { get; set; }

        [Display(Name = "Issue PO?")]
        public string IssuePO { get; set; }

        [Display(Name = "PO Number")]
        public string PONumber { get; set; }

        public int QuoteID { get; set; }
        public virtual Quote Quote { get; set; }
    }
}