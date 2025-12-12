using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations
{
    public class TicketRepository: Repository<Ticket>, ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
