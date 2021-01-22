using System;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Application.Profiles;
using Sample.Novel.Domain;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Sample.Novel.Application
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(NovelDomainModule)
        )]
    public class NovelApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AuthorProfile>(true);
            });
        }
    }
}
