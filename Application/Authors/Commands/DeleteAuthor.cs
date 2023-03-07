using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using MediatR;

namespace Application.Authors.Commands
{
    public class DeleteAuthorCommand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public DeleteAuthorCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _booksStoreDbContext.Authors.FindAsync(request.Id);

            //if (author == null)
            // not found exception here

            _booksStoreDbContext.Authors.Remove(author);
            await _booksStoreDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
