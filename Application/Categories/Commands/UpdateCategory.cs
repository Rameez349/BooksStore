using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public UpdateCategoryCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            _booksStoreDbContext.Categories.Update(new Category { Id = request.Id, Name = request.Name });
            return await _booksStoreDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
