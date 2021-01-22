using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Sample.Novel.Domain.Author.Entities;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Validation;
using Xunit;

namespace Sample.Novel.EntityFrameworkCore.Tests.UnitTests
{
    public class AuthorRepositoryTests : NovelEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IGuidGenerator _guidGenerator;

        public AuthorRepositoryTests()
        {
            _authorRepository = GetRequiredService<IRepository<Author, Guid>>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Author()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var result = await _authorRepository.InsertAsync(new Author(
                    _guidGenerator.Create(),
                    "张家老三",
                    "中国内地不知名网络小说作家"));

                result.Id.ShouldNotBe(Guid.Empty);
            });
        }

        [Fact]
        public async Task Should_Get_List_Of_Authors()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var result = await _authorRepository.GetListAsync();
                result.Count.ShouldBeGreaterThan(0);
            });
        }
    }
}
