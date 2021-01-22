using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain.Book.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mappings
{
    public class ChapterMap : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable(nameof(Chapter));

            builder.ConfigureByConvention();

            builder.Property(chapter => chapter.Title)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasOne(chapter => chapter.ChapterText)
                .WithOne(text => text.Chapter)
                .HasForeignKey<ChapterText>(text => text.Id);

        }
    }
}
