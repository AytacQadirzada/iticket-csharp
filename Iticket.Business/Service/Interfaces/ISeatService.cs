using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface ISeatService
    {
        public Task<List<SeatResponse>> GetAll();
        public Task<SeatResponse> Get(int id);
        public Task Create(SeatRequestDto request);
        public Task Delete(int id);
    }
}
