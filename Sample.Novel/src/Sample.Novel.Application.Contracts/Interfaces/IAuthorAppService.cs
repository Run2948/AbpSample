using System;
using System.Threading.Tasks;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface IAuthorAppService : IApplicationService
    {
        Task CreateAsync(CreateAuthorInput input);

        Task<AuthorDto> GetAsync(Guid id);

        Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
