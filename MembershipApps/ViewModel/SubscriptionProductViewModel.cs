using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Memberships.Entities;

namespace MembershipApps.ViewModel
{
    public class SubscriptionProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public SubscriptionProduct SubscriptionProduct { get; set; }

    }
}