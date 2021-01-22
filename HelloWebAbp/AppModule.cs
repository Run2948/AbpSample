using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace HelloWebAbp
{
    /// <summary>
    /// 启动模块
    ///     TODO: 1.在启动模块中配置 ASP.NET Core Web 程序的管道，就需要定义对 ASP.NET Core Mvc模块的依赖
    /// </summary>
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class AppModule : AbpModule
    {
        /// <summary>
        /// 应用初始化方法
        ///     TODO: 2.重写 ABP 应用的初始化方法，用来构建 ASP.NET Core 应用程序的中间件管道
        /// </summary>
        /// <param name="context"></param>
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            // base.OnApplicationInitialization(context);

            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // TODO: 5.将 程序应用的端点配置 修改为 ABP 应用的端点配置
            app.UseConfiguredEndpoints();
        }
    }
}
