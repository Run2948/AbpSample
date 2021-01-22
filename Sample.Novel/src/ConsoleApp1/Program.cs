using System;
using Volo.Abp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = AbpApplicationFactory.Create<TestModule>(options =>
            {
                options.UseAutofac();
            });
            application.Initialize();
        }
    }
}
