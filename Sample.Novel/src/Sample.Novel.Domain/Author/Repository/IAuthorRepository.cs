using System;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Author.Repository
{
    public interface IAuthorRepository : IRepository<Entities.Author, Guid>
    {
    }
}
