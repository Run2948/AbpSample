using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Domain;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.EntityFrameworkCore.DbMigrations
{
    public class NovelEntityFrameworkCoreDbSchemaMigrator 
        : INovelDbSchemaMigrator, ITransientDependency
    {
        
        private readonly IServiceProvider _serviceProvider;

        public NovelEntityFrameworkCoreDbSchemaMigrator( IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task MigrateAsync()
        {
            var context = _serviceProvider
                .GetRequiredService<NovelMigrationsDbContext>();

            await context.Database.MigrateAsync();
        }
    }
}