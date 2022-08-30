using System;
using System.Collections.Generic;

namespace OpenAPI.Models.Entity
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? Category { get; set; }

        public virtual Category? CategoryNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
