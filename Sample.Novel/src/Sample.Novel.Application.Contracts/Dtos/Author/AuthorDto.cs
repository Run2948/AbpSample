using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Author
{
    public class AuthorDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
