using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualConcierge.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}

