using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Sample.Novel.Domain.Book.Entities;
using Volo.Abp.Domain.Services;

namespace Sample.Novel.Domain.Book.Services
{
    public interface IBookDomainService : IDomainService
    {
        Task<Entities.Book> CreateBook(Entities.Book book);

        Task UpdateBook(Entities.Book book);

        Task RemoveBook(Entities.Book book);

        Task<Entities.Book> FindBookById(Guid id);

        Task<Volume> CreateVolume(Entities.Book book, Volume volume);

        Task<Chapter> CreateChapter(Entities.Book book, Volume volume, Chapter chapter);
    }
}
