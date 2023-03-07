using Application.Books.Commands;
using Application.Books.DTOs.requests;
using Application.Mappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddBookRequest request)
        {
            var addBookCommand = request.MapToAddBookCommand();

            var result = await _mediator.Send(addBookCommand);

            return Ok(result);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBookRequest request)
        {
            var updateBookCommand = request.MapToUpdateBookCommand();

            var result = await _mediator.Send(updateBookCommand);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deleteBookCommand = new DeleteBookCommand { Id = id };

            await _mediator.Send(deleteBookCommand);

            return NoContent();
        }
    }
}
