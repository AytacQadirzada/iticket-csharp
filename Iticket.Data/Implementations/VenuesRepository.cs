using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations
{
    public class VenuesRepository: Repository<Venues>, IVenuesRepository
    {
        private readonly AppDbContext _context;
        public VenuesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
