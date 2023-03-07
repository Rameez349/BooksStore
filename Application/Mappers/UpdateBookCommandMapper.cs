using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Books.Commands;
using Application.Books.DTOs.requests;
using Domain.Entities;

namespace Application.Mappers
{
    public static class UpdateBookCommandMapper
    {
        public static UpdateBookCommand MapToUpdateBookCommand(this UpdateBookRequest request)
        {
            var updateBookCommand = new UpdateBookCommand
            {
                Id = request.bookId,
                AuthorId = request.authorId,
                Price = request.price,
                Title = request.title,
                Categories = request.categories.ToList()
            };

            return updateBookCommand;
        }
    }
}
