using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Category
{
    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
