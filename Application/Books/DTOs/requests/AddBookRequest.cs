using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.DTOs.requests
{
    public record AddBookRequest(long authorId, string title, decimal price, IEnumerable<long> categories);
}
