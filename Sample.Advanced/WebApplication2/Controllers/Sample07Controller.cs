using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace WebApplication3.Controllers
{
    [Route("api/{controller}")]
    public class Sample07Controller : AbpController
    {
        private readonly ILogger<Sample07Controller> _logger;
        public Sample07Controller(ILogger<Sample07Controller> logger)
        {
            _logger = logger;
        }

        public ObjectResult Get()
        {
            _logger.LogError("错误日志");
            return Ok("OK");
        }
    }
}
