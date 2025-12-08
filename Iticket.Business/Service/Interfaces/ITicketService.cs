using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;

namespace Iticket.Business.Service.Interfaces
{
    public interface ITicketService
    {
        public Task<List<TicketResponse>> GetAll();
        public Task<TicketResponse> Get(int id);
        public Task Create(TicketRequestDto request);
        public Task BulkInsert(List<TicketRequestDto> request);
        public Task Delete(int id);
    }
}
