using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain.Book.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mappings
{
    public class ChapterTextMap : IEntityTypeConfiguration<ChapterText>
    {
        public void Configure(EntityTypeBuilder<ChapterText> builder)
        {
            builder.ToTable(nameof(ChapterText));

            builder.ConfigureByConvention();

            builder.Property(text => text.Content)
                .HasColumnType("ntext")
                .HasMaxLength(8000)
                .IsRequired();

            builder.Property(text => text.AuthorMessage)
                .HasMaxLength(2000);
        }
    }
}
