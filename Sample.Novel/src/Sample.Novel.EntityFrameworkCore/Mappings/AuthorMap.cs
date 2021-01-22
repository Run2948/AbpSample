using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain.Author.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(nameof(Author));

            builder.ConfigureByConvention();

            builder.Property(author => author.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(author => author.Description)
                .HasMaxLength(100);
        }
    }
}
