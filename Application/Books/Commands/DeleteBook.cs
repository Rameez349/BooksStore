using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Books.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBooksStoreDbContext _booksStoreDbContext;

        public DeleteBookCommandHandler(IBooksStoreDbContext booksStoreDbContext)
        {
            _booksStoreDbContext = booksStoreDbContext;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _booksStoreDbContext.Books.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == request.Id);

            //if (book == null)
            //not found exception here

            _booksStoreDbContext.Books.Remove(book);

            await _booksStoreDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
