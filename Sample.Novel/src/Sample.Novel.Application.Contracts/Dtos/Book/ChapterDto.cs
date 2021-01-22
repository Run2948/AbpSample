using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos.Book
{
    public class ChapterDto : Entity<Guid>, IHasCreationTime 
    {
        public VolumeDto Volume { get; set; }

        public string Title { get; set; }

        public int WordsNumber { get; set; }

        public ChapterTextDto ChapterText { get; set; }

        public DateTime CreationTime { get; set; }

    }

}
