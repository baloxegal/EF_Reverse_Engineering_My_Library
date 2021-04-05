using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Reverse_Engineering_My_Library
{
    public partial class Order
    {
        public Order()
        {
            BookOrders = new HashSet<BookOrder>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<BookOrder> BookOrders { get; set; }
    }
}
