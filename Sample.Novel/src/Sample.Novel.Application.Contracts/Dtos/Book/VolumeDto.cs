using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos.Book
{
    public class VolumeDto : Entity<Guid>, IHasCreationTime
    {
        public virtual BookDto Book { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual List<ChapterDto> Chapters { get; protected set; }

        public DateTime CreationTime { get; set; }
    }
}
