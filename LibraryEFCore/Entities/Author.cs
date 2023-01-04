using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEFCore.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
        
    }
}
