using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos.Book
{
    public class ChapterTextDto : Entity<Guid>
    {
        public ChapterDto Chapter { get; set; }

        public string Content { get; set; }
        public string AuthorMessage { get; set; }
    }
}
