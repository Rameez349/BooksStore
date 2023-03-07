using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; } = default!;
        public decimal Price { get; set; }
        public Author Author { get; set; } = null!;
        public long AuthorId { get; set; }
        public ICollection<Category>? Categories { get; set; } = null!;
    }
}
