using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entities
{
    /// <summary>
    /// 小说
    /// </summary>
    public class Book : Entity<Guid> , IHasCreationTime
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }
        
        public string AuthorName { get; set; }
        
        public Guid CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public List<Volume> Volumes { get; protected set; }

        public DateTime CreationTime { get; set; }

        protected Book()
        {

        }

        public Book(
            Guid id,
            [NotNull] string name,
            [NotNull] string description,
            Guid authorId,
            [NotNull] string authorName,
            Guid categoryId,
            [NotNull] string categoryName
        )
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = Check.NotNullOrWhiteSpace(description, nameof(description));
            AuthorId = authorId;
            AuthorName = Check.NotNullOrWhiteSpace(authorName, nameof(authorName));
            CategoryId = categoryId;
            CategoryName = Check.NotNullOrWhiteSpace(categoryName, nameof(categoryName));
            Volumes = new List<Volume>();
        }

        public void AddVolume(Volume volume)
        {
            if (Volumes.Any(v => v.Title == volume.Title))
            {
                return;
            }

            Volumes.Add(volume);
        }
    }
}
