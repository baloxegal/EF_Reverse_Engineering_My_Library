using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Reverse_Engineering_My_Library
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Card { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
