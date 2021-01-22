using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Author.Repository;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using Sample.Novel.EntityFrameworkCore.Extensions;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class BookRepository : EfCoreRepository<NovelDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default)
        {
            var result = await DbContext.Chapters
                .IncludeIf(include, chapter => chapter.ChapterText)
                .FirstOrDefaultAsync(
                    chapter => chapter.Id == id, 
                    GetCancellationToken(cancellationToken));

            return result;
        }
        
        public override IQueryable<Book> WithDetails()
        {
            return GetQueryable().IncludeDetails(); 
        }
    }
}
