using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations
{
    public class VenueRepository: Repository<Venue>, IVenueRepository
    {
        private readonly AppDbContext _context;
        public VenueRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
