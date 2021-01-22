using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Sample.Novel.Domain.Author.Entities
{
    public class Author : Entity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        protected Author()
        {

        }

        public Author(
            Guid id,
            [NotNull] string name,
            [CanBeNull] string description = null)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
        }
    }
}
