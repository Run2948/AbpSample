using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace HelloWebAbp.Controllers
{
    /// <summary>
    /// 控制器
    ///     TODO: 4. 继承 Abp 框架中的基类控制器（提供了一些便捷的服务和方法）
    /// </summary>
    public class HomeController : AbpController
    {
        public IActionResult Index()
        {
            return Content("Hello world!");
        }
    }
}
