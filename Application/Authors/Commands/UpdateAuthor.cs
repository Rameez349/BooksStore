using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using MediatR;

namespace Application.Authors.Commands
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public UInt16 Age { get; set; }
    }

    public class UpdateCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public UpdateCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _booksStoreDbContext.Authors.Find(request.Id);

            if (author == null)
                return false;

            author.Name = request.Name;
            author.Age = request.Age;

            _booksStoreDbContext.Authors.Update(author);
            return await _booksStoreDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
