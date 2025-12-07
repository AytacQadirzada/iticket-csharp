using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;

namespace Iticket.Business.Service.Implementations
{
    public class TicketService : ITicketService
    {
        public Task Create(TicketRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TicketResponse> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TicketResponse>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
