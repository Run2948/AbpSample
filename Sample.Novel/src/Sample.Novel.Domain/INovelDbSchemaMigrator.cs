using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.Domain
{
    public interface INovelDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}