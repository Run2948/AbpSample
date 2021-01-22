using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace WebApplication2.Controllers
{
    [Route("api/{controller}")]
    public class Sample06Controller : AbpController
    {
        public ObjectResult Get(string exceptionType)
        {
            switch (exceptionType)
            {
                case "AbpInitializationException":
                    throw new AbpInitializationException();

                case "AbpValidationException":
                    throw new AbpValidationException();

                case "EntityNotFoundException":
                    throw new EntityNotFoundException();

                case "AbpAuthorizationException":
                    throw new AbpAuthorizationException();

                default:
                    return Ok(new {exceptionType});
            }
        }
    }
}
