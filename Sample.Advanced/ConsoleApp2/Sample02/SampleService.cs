using System;
using System.Globalization;
using ConsoleApp2.Localization.Sample;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;

namespace ConsoleApp2.Sample02
{
    public class SampleService : ITransientDependency
    {
        private readonly IStringLocalizer<SampleResource> _localizer;
        private readonly ILanguageProvider _languageProvider;

        public SampleService(IStringLocalizer<SampleResource> localizer, ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
            _localizer = localizer;
        }

        public void Test()
        {
            foreach (var languageInfo in _languageProvider.GetLanguagesAsync().Result)
            {
                CultureHelper.Use(languageInfo.CultureName);
                Console.WriteLine($"当前语言：{languageInfo.DisplayName}[{languageInfo.CultureName}]");
                Console.WriteLine(_localizer["HelloMessage", "张三"]);
                Console.WriteLine();
            }
        }
    }
}
