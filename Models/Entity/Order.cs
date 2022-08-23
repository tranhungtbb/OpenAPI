using System;
using System.Collections.Generic;

namespace OpenAPI.Models.Entity
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? Customer { get; set; }
        public int? Product { get; set; }
        public int? Amount { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderName { get; set; }

        public virtual Customer? CustomerNavigation { get; set; }
        public virtual Product? ProductNavigation { get; set; }
    }
}
