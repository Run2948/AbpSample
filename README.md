# APB vNext 框架入门

## 快速入门案例

###  .NET Core 控制台应用

#### 1. 安装 ABP 框架核心依赖

```
Install-Package Volo.Abp.Core -Version 3.3.2
```

#### 2. 新建 ABP 应用的启动模块

`HelloAbpModule.cs`

```csharp
using Volo.Abp.Modularity;

namespace HelloAbp
{
    /// <summary>
    /// 启动模块
    /// </summary>
    public class HelloAbpModule : AbpModule
    {

    }
}
```

#### 3. 新建服务，并注册到启动模块中

`HelloWorldService.cs`

```csharp
using System;
using Volo.Abp.DependencyInjection;

namespace HelloAbp
{
    /// <summary>
    /// TODO: ABP 注册服务方式一： 继承接口
    ///     ISingletonDependency、IScopedDependency、ITransientDependency
    /// </summary>
    public class HelloWorldService : ITransientDependency
    {
        public void Run()
        {
            Console.WriteLine($"{nameof(HelloAbpModule)}-{nameof(HelloWorldService)}: Hello World!");
        }
    }
}
```

#### 4. 根据启动模块创建 ABP应用，调用应用中注册的服务方法

`Program.cs`

```csharp
using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace HelloAbp
{
    class Program
    {
        static void Main(string[] args)
        {
                // 根据启动模块创建 abp 应用
                var application = AbpApplicationFactory.Create<HelloAbpModule>();
                // 初始化 abp 应用
                application.Initialize();
                // 获取应用中注册的服务
                var service = application.ServiceProvider.GetService<HelloWorldService>();
                // 调用应用中的服务方法 
                service.Run();

            Console.ReadKey();
        }
    }
}
```



### ASP.NET Core Web 应用程序

#### 1. 安装 ABP 框架核心依赖

```
Install-Package Volo.Abp.Core -Version 3.3.2
Install-Package Volo.Abp.AspNetCore.Mvc -Version 3.3.2
```

#### 2.新建 ABP 应用的启动模块

`AppModule.cs`

```csharp
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
```

#### 3. 注册 ABP 启动模块，并初始化 ABP 应用

`Startup.cs`

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWebAbp
{
    /// <summary>
    /// 程序启动类
    /// TODO: 3. 在 Startup 类中，完成对 ABP 应用的初始化
    /// </summary>
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AppModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeApplication();
        }
    }
}
```

#### 4. 新建控制器，测试 ABP 应用运行状态

`HomeController.cs`

```csharp
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
```



##  各个击破案例

> ABP应用中的模块可以有很多个，但是启动模块只能有一个；
>
> ABP应用中的每个模块之间没有必然的联系；
>
> ABP应用中每个模块注册的服务，都注册到了ABP应用的全局容器中;
>
> ABP应用中的模块也分为两种类型：应用程序模块(业务实现)和框架模块(技术实现)；
>
> ABP应用中最顶层的模块是启动模块，最后被加载的也是启动模块。

###  在模块中注册自定义服务

`HelloAbpModule.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace HelloAbp
{
    /// <summary>
    /// 启动模块
    /// </summary>
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
```

**小结**

>**初始化ABP模块**
>
>* 1.注册ABP基础设施与核心服务（模块系统相关）
>* 2.加载整个应用的所有模块，按照依赖性排序
>* 3.按顺序遍历所有模块，执行每一个模块的配置方法
>* 4.按顺序遍历所有模块，执行每一个模块的初始化方法

### 使用标签属性注册自定义服务

`HelloWorldService.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace HelloAbp
{
    /// <summary>
    /// TODO: ABP 注册服务方式三： 特性标签
    ///     ServiceLifetime.Singleton、ServiceLifetime.Scoped、ServiceLifetime.Transient
    /// </summary>
    [Dependency(ServiceLifetime.Transient)]
    public class HelloWorldService
    {
        public void Run()
        {
            Console.WriteLine($"{nameof(HelloAbpModule)}-{nameof(HelloWorldService)}: Hello World!");
        }
    }
}
```



###  