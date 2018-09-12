using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Memberships.Entities
{
    public class UserSubscription
    {

        public int Id { get; set; }

        [Required]
        public int SubscriptionId { get; set; }

        [Required]
        [MaxLength(128)]
        public string UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}