using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public DeleteCategoryCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var targetEntity = await _booksStoreDbContext.Categories.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == request.Id);
            //if (targetEntity == null) return false;

            _booksStoreDbContext.Categories.Remove(targetEntity);

            await _booksStoreDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
