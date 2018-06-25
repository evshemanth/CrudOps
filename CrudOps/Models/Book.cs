using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudOps.Common;

namespace CrudOps.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums.SegmentType Segment { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}