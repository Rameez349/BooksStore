using Application.Authors.Commands;
using Application.Authors.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorRequest request)
        {
            var addAuthorCommand = new AddAuthorCommand { Name = request.name, Age = request.Age };

            var result = await _mediator.Send(addAuthorCommand);

            return Ok(result);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorRequest request)
        {
            var updateAuthorCommand = new UpdateAuthorCommand { Id = request.Id, Name = request.name, Age = request.age };

            var result = await _mediator.Send(updateAuthorCommand);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] long id)
        {
            var deleteAuthorCommand = new DeleteAuthorCommand {Id = id };

            await _mediator.Send(deleteAuthorCommand);

            return NoContent();
        }
    }
}
