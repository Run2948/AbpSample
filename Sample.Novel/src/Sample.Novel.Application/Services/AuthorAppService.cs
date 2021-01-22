using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Application.Contracts.Interfaces;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Author.Repository;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Services
{
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorAppService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        
        public async Task CreateAsync(CreateAuthorInput input)
        {
            var author = ObjectMapper.Map<CreateAuthorInput, Author>(input);
            await _authorRepository.InsertAsync(author);
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var count = await _authorRepository.CountAsync();
            var list = await _authorRepository.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<AuthorDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list)
            };
        }
    }
}
