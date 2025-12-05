using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface IVenuesService
    {
        public Task<List<VenuesResponse>> GetAll();
        public Task<VenuesResponse> Get(int id);
        public Task Create(VenuesRequestDto request);
        public Task Delete(int id);
    }
}
