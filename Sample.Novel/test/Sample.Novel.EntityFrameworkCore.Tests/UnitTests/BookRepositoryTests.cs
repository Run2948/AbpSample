using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Xunit;

namespace Sample.Novel.EntityFrameworkCore.Tests.UnitTests
{
    public class BookRepositoryTests : NovelEntityFrameworkCoreTestBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGuidGenerator _guidGenerator;

        public BookRepositoryTests()
        {
            _bookRepository = GetRequiredService<IBookRepository>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Book()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = new Book(
                    _guidGenerator.Create(),
                    "三体",
                    "地球人类文明和三体文明",
                    _guidGenerator.Create(),
                    "刘慈欣",
                    _guidGenerator.Create(),
                    "科幻");

                return await _bookRepository.InsertAsync(book);
            });

            result.CreationTime.ShouldNotBe(default);
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Volume()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "盗墓笔记");
                book.AddVolume(new Volume("秦岭神树"));
                return await _bookRepository.UpdateAsync(book);
            });
            
            result.Volumes.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Chapter()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "盗墓笔记");
                book.Volumes[0].AddChapter(new Chapter("第二章", "正文2"));
                return await _bookRepository.UpdateAsync(book);
            });
            
            result.Volumes[0].Chapters.Count.ShouldBe(2);
        }


        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await WithUnitOfWorkAsync(async () => 
                await _bookRepository.GetListAsync());

            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_A_Book_Without_Catalog()
        {
            var result = await WithUnitOfWorkAsync(async () =>
                await _bookRepository.GetAsync(b => b.Name == "盗墓笔记")
                );

            result.ShouldNotBeNull();
            result.Volumes.Count.ShouldBe(1);
            result.Volumes[0].Chapters.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_A_Chapter()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "盗墓笔记");
                var chapterId = book.Volumes[0].Chapters[0].Id;
                return await _bookRepository.FindChapterByIdAsync(chapterId);
            });

            result.ShouldNotBeNull();
            result.WordsNumber.ShouldBeGreaterThan(0);
            result.ChapterText.ShouldNotBeNull();
            result.ChapterText.Content.ShouldNotBeNullOrEmpty();
        }
    }
}
