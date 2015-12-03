using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartsR2.Models
{
    public enum PriorityLevel
    {
        Urgent, High, Medium, Low, Normal, Other,
    }

    public enum StatusLevel
    {
        Assigned, Working, ReviewNeeded, ReviewComplete, Completed, OnHold, Other
    }

    public class File
    {
        [Key]
        public int FileID { get; set; }

        [Display(Name = "Research Requested File")]
        public string ResearchReqFile { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Research Assigned")]
        public string DateResearchAssigned { get; set; }

        [Display(Name = "Priority Level")]
        public PriorityLevel PriorityLevel { get; set; }

        [Display(Name = "Status Level")]
        public StatusLevel StatusLevel { get; set; }


        public virtual ICollection<Quote> Quotes { get; set; }
        //public virtual ICollection<Part> Parts { get; set; }
    }
}