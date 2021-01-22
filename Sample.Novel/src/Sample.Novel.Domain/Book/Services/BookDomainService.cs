using System;
using System.Linq;
using System.Threading.Tasks;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace Sample.Novel.Domain.Book.Services
{
    public class BookDomainService : DomainService, IBookDomainService
    {
        private readonly IBookRepository _bookRepository;

        public BookDomainService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Entities.Book> CreateBook(Entities.Book book)
        {
            if (_bookRepository.Any(v => v.Name == book.Name))
            {
                throw new Exception("书名已存在");
            }

            return await _bookRepository.InsertAsync(book, true);
        }

        public async Task UpdateBook(Entities.Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }

        public async Task RemoveBook(Entities.Book book)
        {
            await _bookRepository.DeleteAsync(book);
        }

        public async Task<Entities.Book> FindBookById(Guid id)
        {
            return await _bookRepository.FindAsync(id);
        }

        public async Task<Volume> CreateVolume(Entities.Book book, Volume volume)
        {
            // book = await _bookRepository.FindAsync(b => b.Id == book.Id);
            //
            // if (book == null)
            // {
            //     throw new Exception("Book不存在");
            // }
            //
            // if (book.Volumes.Any(v => v.Title == volume.Title))
            // {
            //     throw new Exception("卷已存在");
            // }
            //
            // book.AddVolume(volume);
            // await _bookRepository.UpdateAsync(book, true);
            return volume;
        }

        public async Task<Chapter> CreateChapter(Entities.Book book, Volume volume, Chapter chapter)
        {
            // if (volume.Chapters.Any(v => v.Title == volume.Title))
            // {
            //     return chapter;
            // }
            //
            // volume.AddChapter(chapter);
            // await _bookRepository.UpdateAsync(book);
        
            return chapter;
        }
    }
}
