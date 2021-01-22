using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entities
{
    public class ChapterText : Entity<Guid>
    {
        public Chapter Chapter { get; set; }

        public string Content { get; set; }
        public string AuthorMessage { get; set; }

        protected ChapterText()
        {

        }

        public ChapterText(
            [NotNull] string content,
            [CanBeNull] string authorMessage = null)
        {
            Content = Check.NotNullOrWhiteSpace(content, nameof(content));
            AuthorMessage = authorMessage;
        }
    }
}
