using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Reverse_Engineering_My_Library
{
    public partial class BookOrder
    {
        public int OrdersId { get; set; }
        public int PurchasesId { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Book Purchases { get; set; }
    }
}
