using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Books.Commands
{
    public class AddBookCommand : IRequest<bool>
    {
        public string Title { get; set; } = default!;
        public decimal Price { get; set; }
        public long AuthorId { get; set; }
        public List<Category>? Categories { get; set; }
    }

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, bool>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public AddBookCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            if (request.Categories != null)
            {
                _booksStoreDbContext.Categories.AttachRange(request.Categories);
            }

            var bookEntity = new Book
            {
                Title = request.Title,
                Price = request.Price,
                AuthorId = request.AuthorId,
                Categories = request.Categories
            };

            _booksStoreDbContext.Books.Add(bookEntity);
            return await _booksStoreDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
