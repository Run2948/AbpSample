using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sample.Novel.Domain.Book.Entities;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Book.Repository
{
    public interface IBookRepository : IRepository<Entities.Book, Guid>
    {

        Task<Chapter> FindChapterByIdAsync(
            Guid id,
            bool include = true,
            CancellationToken cancellationToken = default);
    }
}
