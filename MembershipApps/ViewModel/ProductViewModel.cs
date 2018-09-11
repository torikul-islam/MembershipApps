using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MembershipApps.Areas.Admin.Controllers;
using Memberships.Entities;

namespace MembershipApps.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<ProductLinkText> ProductLinkTexts { get; set; }
        public Product Product { get; set; }

    }
}