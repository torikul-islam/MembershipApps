using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Memberships.Entities;

namespace MembershipApps.ViewModel
{
    public class ProductItemViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public ProductItem ProductItem { get; set; }

    }
}