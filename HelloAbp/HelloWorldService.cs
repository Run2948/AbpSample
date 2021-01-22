using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace HelloAbp
{
    // /// <summary>
    // /// TODO: ABP 注册服务方式一： 继承接口
    // ///     ISingletonDependency、IScopedDependency、ITransientDependency
    // /// </summary>
    // public class HelloWorldService : ITransientDependency
    // {
    //     public void Run()
    //     {
    //         Console.WriteLine($"{nameof(HelloAbpModule)}-{nameof(HelloWorldService)}: Hello World!");
    //     }
    // }

    // public class HelloWorldService
    // {
    //     public void Run()
    //     {
    //         Console.WriteLine($"{nameof(HelloAbpModule)}-{nameof(HelloWorldService)}: Hello World!");
    //     }
    // }

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
