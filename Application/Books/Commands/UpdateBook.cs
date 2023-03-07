using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Books.Commands
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Title { get; set; } = default!;
        public decimal Price { get; set; }
        public long AuthorId { get; set; }
        public List<long> Categories { get; set; } = default!;
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public UpdateBookCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = _booksStoreDbContext.Books.Include(x => x.Categories).FirstOrDefault(x => x.Id == request.Id);

            if (result == null)
                return false;

            result.Title = request.Title;
            result.Price = request.Price;
            result.AuthorId = request.AuthorId;
            result.Categories?.Clear();
            result.Categories = await _booksStoreDbContext.Categories.Where(x => request.Categories.Contains(x.Id)).ToListAsync();

            _booksStoreDbContext.Books.Update(result);
            return await _booksStoreDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
