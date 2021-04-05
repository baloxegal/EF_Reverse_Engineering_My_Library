using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Reverse_Engineering_My_Library
{
    public partial class AuthorsBook
    {
        public int AuthorsId { get; set; }
        public int BooksId { get; set; }

        public virtual Author Authors { get; set; }
        public virtual Book Books { get; set; }
    }
}
