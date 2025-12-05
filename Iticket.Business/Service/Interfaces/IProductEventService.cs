using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface IProductEventService
    {
        public Task<List<ProductEventResponse>> GetAll();
        public Task<ProductEventResponse> Get(int id);
        public Task Create(ProductEventRequestDto request);
        public Task Delete(int id);
    }
}
