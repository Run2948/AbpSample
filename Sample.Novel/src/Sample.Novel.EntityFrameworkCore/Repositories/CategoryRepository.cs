using System;
using System.Collections.Generic;
using System.Text;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Author.Repository;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using Sample.Novel.Domain.Category.Entities;
using Sample.Novel.Domain.Category.Repository;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : EfCoreRepository<NovelDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
