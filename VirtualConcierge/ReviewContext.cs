using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VirtualConcierge.Models;

namespace VirtualConcierge
{
    public class ReviewContext : DbContext
    {
        public ReviewContext() : base()
        {

        }

        public DbSet<Review> Reviews { get; set; }
    }
}