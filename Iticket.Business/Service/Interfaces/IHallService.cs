using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface IHallService
    {
        public Task<List<HallResponse>> GetAll();
        public Task<HallResponse> Get(int id);
        public Task Create(HallRequestDto request);
        public Task Delete(int id);
    }
}
