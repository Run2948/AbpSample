using ConsoleApp2.Localization.Sample;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ConsoleApp2.Sample01
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class SampleAbpModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SampleAbpModule>(
                    baseNamespace: nameof(ConsoleApp2), 
                    baseFolder:"Localization");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<SampleResource>("zh-Hans")
                    .AddVirtualJson("/Localization/Sample/Resources");

                options.DefaultResourceType = typeof(SampleResource);
            });
        }
    }


}
