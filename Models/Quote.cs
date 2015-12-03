using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartsR2.Models
{
    public enum ContactMethod
    {
        Phone, Email, Fax, International
    }

    public enum ListingService
    {
        ILS, PartsBase, Fipart, DatAccess, OneAero, PartsLogistics, Controller, Other
    }

    public class Quote
    {
        [Key]
        public int QuoteID { get; set; }

        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Contact Date")]
        public DateTime ContactDate { get; set; }

        [Display(Name = "Listing Service")]
        public ListingService ListingService { get; set; }

        [Display(Name = "Contact Method")]
        public ContactMethod ContactMethod { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }

        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Display(Name = "Contact Fax")]
        public string ContactFax { get; set; }

        public int FileID { get; set; }
        public virtual File File { get; set; }

        // All added while trying to figure out controller situation. Worked correctly, I think, before these additions. Try an ICollection of Part if virtual doesn't work.

        //public int PartID { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}