# APB vNext 框架入门

##  .NET Core 控制台应用

### 1. 安装 ABP 框架核心依赖

```
Install-Package Volo.Abp.Core -Version 3.3.2
```

### 2. 新建 ABP 启动模块

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

### 3. 新建服务，并注册到启动模块中

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

### 4. 根据启动模块创建 ABP应用，调用应用中注册的服务方法

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



## ASP.NET Core Web 应用程序

### 1. 安装 ABP 框架核心依赖

```
Install-Package Volo.Abp.Core -Version 3.3.2
Install-Package Volo.Abp.AspNetCore.Mvc -Version 3.3.2
```