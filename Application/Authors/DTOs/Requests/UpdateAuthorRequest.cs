using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.DTOs.Requests
{
    public record UpdateAuthorRequest(long Id, string name, UInt16 age);
}
