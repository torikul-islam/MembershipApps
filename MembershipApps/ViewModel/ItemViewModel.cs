using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Memberships.Entities;

namespace MembershipApps.ViewModel
{
    public class ItemViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ItemType> ItemTypes { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public IEnumerable<Part> Parts { get; set; }
        public Item Item{ get; set; }

    }
}