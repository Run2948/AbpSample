using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entities
{
    public class Volume : Entity<Guid>, IHasCreationTime
    {

        public virtual Book Book { get; set; }

        public Guid BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual List<Chapter> Chapters { get; protected set; }

        public DateTime CreationTime { get; set; }

        protected Volume()
        {

        }

        public Volume(
            [NotNull] string title,
            [CanBeNull] string description = null
        )
        {
            Title = title;
            Description = description;
            Chapters = new List<Chapter>();
        }

        public void AddChapter(Chapter chapter)
        {
            if (Chapters.Any(c => c.Title == chapter.Title))
            {
                return;
            }
            
            Chapters.Add(chapter);
        }
    }
}
