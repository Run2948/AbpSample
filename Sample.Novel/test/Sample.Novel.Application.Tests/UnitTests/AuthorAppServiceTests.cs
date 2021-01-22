using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Application.Contracts.Interfaces;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Book.Repository;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Guids;
using Xunit;

namespace Sample.Novel.Application.Tests.UnitTests
{
    public class AuthorAppServiceTests : NovelApplicationTestBase
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorAppServiceTests()
        {
            _authorAppService = GetRequiredService<IAuthorAppService>();
        }

        [Fact]
        public async Task Should_Create_A_Valid_Author()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                await Should.NotThrowAsync(async () =>
                {
                    var input = new CreateAuthorInput
                    {
                        Name = "张家老三",
                        Description = "中国内地不知名网络小说作家"
                    };
                    await _authorAppService.CreateAsync(input);
                });
            });
        }

        [Fact]
        public async Task Should_Get_PagedAndSorted_Of_Authors()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var input = new PagedAndSortedResultRequestDto
                {
                    SkipCount = 0,
                    MaxResultCount = 10,
                    Sorting = "Name"
                };

                return await _authorAppService.GetListAsync(input);
            });

            result.TotalCount.ShouldBe(1);
            result.Items.Count.ShouldBe(1);
        }
    }
}
