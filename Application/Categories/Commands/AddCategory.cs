using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Categories.Commands
{
    public class AddCategoryCommand : IRequest<bool>
    {
        public string Name { get; set; } = default!;
    }

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, bool>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public AddCategoryCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task<bool> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            _booksStoreDbContext.Categories.Add(new Category { Name = request.Name });
            return await _booksStoreDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
