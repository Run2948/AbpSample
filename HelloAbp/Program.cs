using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace HelloAbp
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                // 根据启动模块创建 abp 应用
                var application = AbpApplicationFactory.Create<HelloAbpModule>();
                // 初始化 abp 应用
                application.Initialize();
                // 获取应用中注册的服务
                var service = application.ServiceProvider.GetService<HelloWorldService>();
                // 调用应用中的服务方法 
                service.Run();
            }


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
