using System.ComponentModel.DataAnnotations;

namespace Application.Authors.DTOs.Requests
{
    public record AddAuthorRequest([Required] string name, [Required] UInt16 Age);
}
