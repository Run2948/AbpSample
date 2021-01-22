using System;
using System.Collections.Generic;
using System.Text;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Author.Repository;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class AuthorRepository : EfCoreRepository<NovelDbContext, Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
