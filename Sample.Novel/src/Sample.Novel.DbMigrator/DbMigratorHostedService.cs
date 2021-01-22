using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Novel.Domain;
using Sample.Novel.EntityFrameworkCore.DbMigrations;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var application = AbpApplicationFactory.Create<NovelDbMigratorModule>(options =>
            {
                options.UseAutofac();
            });

            application.Initialize();

            //
            // await application
            //     .ServiceProvider
            //     .GetRequiredService<NovelDbMigrationService>()
            //     .MigrateAsync();

            application.Shutdown();

            _hostApplicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}