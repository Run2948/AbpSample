﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace HelloAbp
{
    /// <summary>
    /// 启动模块
    /// </summary>
    // TODO: 使用 Autofac 第三方依赖注入框架（提供了更多的高级特性）
    [DependsOn(typeof(AbpAutofacModule))]
    public class HelloAbpModule : AbpModule
    {
        // TODO: 重写 ABP 模块的服务配置方法，向模块中注册自定义的服务
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);

            // TODO: ABP 注册服务方式二： 模块注册
            context.Services.AddTransient<HelloWorldService>();
        }
    }
}
