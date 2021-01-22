using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.Domain
{
    public class NovelDbMigrationService : ITransientDependency
    {
        // public ILogger<NovelDbMigrationService> Logger { get; set; }

        private readonly IDataSeeder _dataSeeder;

        // private readonly INovelDbSchemaMigrator _dbSchemaMigrator;

        // public NovelDbMigrationService(IDataSeeder dataSeeder, INovelDbSchemaMigrator dbSchemaMigrator)
        // {
        //     _dataSeeder = dataSeeder;
        //     _dbSchemaMigrator = dbSchemaMigrator;
        // }

        private readonly IEnumerable<INovelDbSchemaMigrator> _dbSchemaMigrators;

        public NovelDbMigrationService(IDataSeeder dataSeeder, IEnumerable<INovelDbSchemaMigrator> dbSchemaMigrators)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrators = dbSchemaMigrators;
        }

        public NovelDbMigrationService()
        {

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