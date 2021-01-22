using System;
using System.Collections.Generic;
using System.Text;
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
