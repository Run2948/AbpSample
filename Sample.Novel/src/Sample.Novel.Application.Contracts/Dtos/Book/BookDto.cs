using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos.Book
{
    /// <summary>
    /// 小说
    /// </summary>
    public class BookDto : EntityDto<Guid> , IHasCreationTime
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }
        
        public string AuthorName { get; set; }
        
        public Guid CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public List<VolumeDto> Volumes { get; protected set; }

        public DateTime CreationTime { get; set; }
    }
}
