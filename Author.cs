using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Reverse_Engineering_My_Library
{
    public partial class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorsBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<AuthorsBook> AuthorsBooks { get; set; }
    }
}
