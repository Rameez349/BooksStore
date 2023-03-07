using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public UInt16 Age { get; set; }
        public ICollection<Book>? Books { get; set; } = null!;
    }
}
