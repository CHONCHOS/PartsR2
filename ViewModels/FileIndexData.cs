using System.Collections.Generic;
using PartsR2.Models;

namespace PartsR2.ViewModels
{
    public class FileIndexData
    {
        public IEnumerable<File> Files { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }
        public IEnumerable<Part> Parts { get; set; }

    }
}