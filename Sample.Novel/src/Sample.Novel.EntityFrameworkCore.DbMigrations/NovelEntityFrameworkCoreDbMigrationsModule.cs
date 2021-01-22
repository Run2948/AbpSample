using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Sample.Novel.EntityFrameworkCore.DbMigrations
{
    [DependsOn(typeof(NovelEntityFrameworkModule))]
    public class NovelEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<NovelMigrationsDbContext>();
        }
    }
}
