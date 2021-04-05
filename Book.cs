using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Reverse_Engineering_My_Library
{
    public partial class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorsBook>();
            BookOrders = new HashSet<BookOrder>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }

        public virtual ICollection<AuthorsBook> AuthorsBooks { get; set; }
        public virtual ICollection<BookOrder> BookOrders { get; set; }
    }
}
