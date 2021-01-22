using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sample.Novel.Domain.Book.Entities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace Sample.Novel.Domain
{
    public class NovelDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Author.Entities.Author, Guid> _authorRepository;
        private readonly IRepository<Book.Entities.Book, Guid> _bookRepository;
        private readonly IRepository<Category.Entities.Category, Guid> _categoryRepository;
        private readonly List<Guid> _guids;

        public NovelDataSeedContributor(
            IRepository<Author.Entities.Author, Guid> authorRepository,
            IRepository<Book.Entities.Book, Guid> bookRepository,
            IRepository<Category.Entities.Category, Guid> categoryRepository,
            IGuidGenerator guidGenerator)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _guids = new List<Guid>();

            for (int i = 0; i < 3; i++)
            {
                _guids.Add(guidGenerator.Create());
            }
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            Console.WriteLine("11");
            await CreateAuthorAsync();
            await CreateCategoryAsync();
            await CreateBookAsync();
        }

        public async Task CreateAuthorAsync()
        {
            var book = new Author.Entities.Author(
                _guids[0],
                "南派三叔",
                "盗墓笔记作者"
            );
            
            await _authorRepository.InsertAsync(book);
        }

        public async Task CreateCategoryAsync()
        {
            var category = new Category.Entities.Category(
                _guids[1],
                "奇幻"
            );
            
            await _categoryRepository.InsertAsync(category);
        }

        
        public async Task CreateBookAsync()
        {

            var book = new Book.Entities.Book(
                _guids[2],
                "盗墓笔记",
                "盗墓题材小说，讲述古墓探险的故事",
                _guids[0],
                "南派三叔",
                _guids[1],
                "奇幻"
            );

            book.AddVolume(new Volume("七星鲁王宫"));
            book.Volumes[0].AddChapter(new Chapter("第一章", "正文1"));

            await _bookRepository.InsertAsync(book);
        }
    }
}
