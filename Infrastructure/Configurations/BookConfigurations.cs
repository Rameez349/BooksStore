using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));

            builder.HasKey(x => x.Id);
            builder.HasOne<Author>(x => x.Author)
                .WithMany(y => y.Books)
                .HasForeignKey(x => x.AuthorId);
            builder.HasMany<Category>(x => x.Categories);
        }
    }
}
