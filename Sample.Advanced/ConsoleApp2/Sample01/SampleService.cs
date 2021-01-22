using System;
using System.Globalization;
using ConsoleApp2.Localization.Sample;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;

namespace ConsoleApp2.Sample01
{
    public class SampleService : ITransientDependency
    {
        private readonly IStringLocalizer<SampleResource> _localizer;

        public SampleService(IStringLocalizer<SampleResource> localizer)
        {
            _localizer = localizer;
        }

        public void Test()
        { 
            Console.WriteLine("当前地区：" + CultureInfo.CurrentCulture.Name);
            var str = _localizer["HelloMessage", "张三"];
            Console.WriteLine(str);
            
            CultureHelper.Use("en");
            Console.WriteLine("当前地区：" + CultureInfo.CurrentCulture.Name);
            Console.WriteLine(_localizer["HelloMessage", "张三"]);

        }
    }
}
