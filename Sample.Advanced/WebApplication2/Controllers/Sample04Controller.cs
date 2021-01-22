using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;
using WebApplication2.Localization.Exception;

namespace WebApplication2.Controllers
{
    [Route("api/{controller}")]
    public class Sample04Controller : AbpController
    {
        public ObjectResult Get()
        {
            throw new BusinessException("Sample:001");
        }
    }
}
