using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using WebApplication3.Localization.ErrorCode;

namespace WebApplication3.Controllers
{
    [Route("api/{controller}")]
    public class Sample01Controller : AbpController
    {
        public ObjectResult Get()
        {
            throw new BusinessException(SampleErrorCodes.ThisIsABusinessException)
                .WithData("msg","这是一个参数化的错误消息");
        }
    }
}
