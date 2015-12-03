using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartsR2.Models;

namespace PartsR2.ViewModels
{
    public class DetailIndexData
    {
        public virtual IQueryable<File> Files { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}