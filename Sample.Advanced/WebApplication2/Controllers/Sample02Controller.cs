using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace WebApplication2.Controllers
{
    [Route("api/{controller}")]
    public class Sample02Controller : AbpController
    {
        public ObjectResult Get()
        {
            throw new UserFriendlyException("这是一个用户友好异常","Sample:02");
        }
    }
}
