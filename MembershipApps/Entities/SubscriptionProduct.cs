using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Memberships.Entities
{
    [Table("SubscriptionProduct")]
    public class SubscriptionProduct
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Subscription Subscription { get; set; }

        [Required]
        public int SubscriptionId { get; set; }

        [NotMapped]
        public int OldProductId { get; set; }

        [NotMapped]
        public int OldSubscriptionId { get; set; }

    }
}