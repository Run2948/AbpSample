using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Category.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }

        protected Category()
        {

        }

        public Category(
            Guid id,
            [NotNull] string name
        )
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}
