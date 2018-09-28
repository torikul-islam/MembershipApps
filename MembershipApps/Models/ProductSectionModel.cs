using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembershipApps.Models
{
    public class ProductSectionModel
    {
        public string Title { get; set; }
        public List<ProductSection> Sections { get; set; }

    }
}