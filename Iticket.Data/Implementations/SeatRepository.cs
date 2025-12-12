using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations
{
    public class SeatRepository: Repository<Seat> ,ISeatRepository
    {
        private readonly AppDbContext _context;
        public SeatRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
