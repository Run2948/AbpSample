using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.EntityFrameworkCore;
using Sample.Novel.EntityFrameworkCore.DbMigrations;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace ConsoleApp1
{
    [DependsOn(typeof(AbpAutofacModule), typeof(NovelEntityFrameworkCoreDbMigrationsModule))]
    public class TestModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(async () =>
            {
                using var scope = context.ServiceProvider.CreateScope();
                await scope.ServiceProvider
                    .GetRequiredService<IDataSeeder>()
                    .SeedAsync();
            });
        }
    }
}
