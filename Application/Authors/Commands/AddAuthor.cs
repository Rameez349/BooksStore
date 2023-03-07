using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Authors.Commands
{
    public class AddAuthorCommand : IRequest<bool>
    {
        public string Name { get; set; } = default!;
        public UInt16 Age { get; set; }
    }

    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, bool>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public AddAuthorCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task<bool> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                Age = request.Age,
            };

            _booksStoreDbContext.Authors.Add(author);

            return await _booksStoreDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
