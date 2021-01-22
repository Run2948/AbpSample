using System;
using System.Collections.Generic;
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
    class Program
    {
        static async Task Main(string[] args)
        {
            // await CreateHostBuilder(args).RunConsoleAsync();

            using var application = AbpApplicationFactory.Create<NovelDbMigratorModule>(options =>
            {
                options.UseAutofac();
            });
            //
            application.Initialize();
            // var migrate = application
            //     .ServiceProvider
            //     .GetRequiredService<NovelEntityFrameworkCoreDbSchemaMigrator>();

            var seeder = application
                .ServiceProvider
                .GetRequiredService<IDataSeeder>();

            // await migrate.MigrateAsync();

            await seeder.SeedAsync();
            
            // await migrate.MigrateAsync();

            // var a = application
            //     .ServiceProvider
            //     .GetRequiredService<NovelDbMigrationService>();



            application.Shutdown();

        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<DbMigratorHostedService>();
                });
    }

    public class TestServcie : ITransientDependency
    {
        private readonly IDataSeeder _dataSeeder;
        private readonly IEnumerable<INovelDbSchemaMigrator> _dbSchemaMigrators;

        private readonly INovelDbSchemaMigrator _dbSchemaMigrator;

        public TestServcie(
            NovelEntityFrameworkCoreDbSchemaMigrator dbSchemaMigrator)
        {
            // _dataSeeder = dataSeeder;
            // _dbSchemaMigrators = dbSchemaMigrators;
        }
        
        public async Task MigrateAsync()
        {
            // Logger.LogInformation("Started database migrations...");


            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }

            await _dataSeeder.SeedAsync();

            // Logger.LogInformation("Started database migrations...");
        }
    }
}