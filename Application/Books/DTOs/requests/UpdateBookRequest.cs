using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.DTOs.requests
{
    public record UpdateBookRequest(long bookId, long authorId, string title, decimal price, IEnumerable<long> categories);
}
