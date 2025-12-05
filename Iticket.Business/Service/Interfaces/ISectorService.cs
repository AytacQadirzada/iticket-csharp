using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface ISectorService
    {
        public Task<List<SectorResponse>> GetAll();
        public Task<SectorResponse> Get(int id);
        public Task Create(SectorRequestDto request);
        public Task Delete(int id);
    }
}
