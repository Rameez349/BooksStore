using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Books.Commands;
using Application.Books.DTOs.requests;

namespace Application.Mappers
{
    public static class AddBookCommandMapper
    {
        public static AddBookCommand MapToAddBookCommand(this AddBookRequest request)
        {
            var addBookCommand = new AddBookCommand
            {
                Title = request.title,
                Price = request.price,
                AuthorId = request.authorId,
                Categories = new()
            };
            if (request.categories != null)
            {
                foreach (var item in request.categories)
                {
                    addBookCommand.Categories.Add(new Domain.Entities.Category { Id = item });
                }
            }

            return addBookCommand;
        }
    }
}
