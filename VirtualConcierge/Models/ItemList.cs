using System.Collections.Generic;
using BGGAPI.Collection;

namespace VirtualConcierge.Models
{
    public class ItemList
    {
        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the terms of use.
        /// </summary>
        public string TermsOfUse { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<Item> Items { get; set; }
    }
}