using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductResponse>> GetAll();
        public Task<ProductResponse> Get(int id);
        public Task Create(ProductRequestDto request);
        public Task Delete(int id);
        public Task<List<ProductResponse>> GetFilter(FilterRequest request);
        public Task<ProductResponse> GetByTitle(string title);
        public Task<List<ProductResponse>> GetByCategory(string slug);
    }
}
