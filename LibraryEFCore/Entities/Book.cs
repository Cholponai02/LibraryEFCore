using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEFCore.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string TitleBook { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int Page { get; set; }

        public List<Author> Authors { get; set; }

    }
}
