using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos.Book
{
    public class CreateVolumeDto
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
