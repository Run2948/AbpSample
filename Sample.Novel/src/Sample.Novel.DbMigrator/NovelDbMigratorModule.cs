using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Domain;
using Sample.Novel.EntityFrameworkCore.DbMigrations;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Sample.Novel.DbMigrator
{
    [DependsOn(typeof(AbpAutofacModule),
        typeof(NovelEntityFrameworkCoreDbMigrationsModule))]
    public class NovelDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }

        
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var seeder = context
                .ServiceProvider.CreateScope().ServiceProvider
                .GetRequiredService<IDataSeeder>();

            AsyncHelper.RunSync(async () =>
            {
                await seeder.SeedAsync();
            });
            
        }
    }
}