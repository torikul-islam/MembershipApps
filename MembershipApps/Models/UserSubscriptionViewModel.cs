using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Memberships.Entities;

namespace MembershipApps.Models
{
    public class UserSubscriptionViewModel
    {
        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<UserSubscriptionModel> UserSubscriptionModels { get; set; }
        public bool DisableDropDown { get; set; }
        public string UserId { get; set; }
        public int SubscriptionId { get; set; }


    }
}