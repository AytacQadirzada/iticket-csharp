using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponse>> GetAll();
        public Task<CategoryResponse> Get(int id);
        public Task Create(CategoryRequestDto request);
        public Task Delete(int id);
    }
}
