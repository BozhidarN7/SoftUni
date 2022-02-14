using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid().ToString();
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
