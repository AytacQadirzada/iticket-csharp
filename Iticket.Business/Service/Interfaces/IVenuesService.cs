using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface IVenueService
    {
        public Task<List<VenueResponse>> GetAll();
        public Task<VenueResponse> Get(int id);
        public Task Create(VenueRequestDto request);
        public Task Delete(int id);
    }
}
