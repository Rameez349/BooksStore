using Application.Categories.Commands;
using Application.Categories.DTOs.requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            var addCategoryCommand = new AddCategoryCommand { Name = request.categoryName };
            var result = await _mediator.Send(addCategoryCommand);

            return Ok(result);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            var updateCategoryCommand = new UpdateCategoryCommand { Id = request.id, Name = request.categoryName };
            var result = await _mediator.Send(updateCategoryCommand);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] long id)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(deleteCategoryCommand);

            return NoContent();
        }
    }
}
