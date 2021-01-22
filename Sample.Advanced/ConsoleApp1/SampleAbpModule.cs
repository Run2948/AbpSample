using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ConsoleApp1
{
    [DependsOn(typeof(AbpVirtualFileSystemModule))]
    public class SampleAbpModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SampleAbpModule>(
                    baseNamespace: nameof(ConsoleApp1), 
                    baseFolder:"MyResources");
            });
        }
    }


}
