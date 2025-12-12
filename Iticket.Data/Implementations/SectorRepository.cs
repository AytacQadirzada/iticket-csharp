using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations
{
    public class SectorRepository: Repository<Sector>, ISectorRepository
    {
        private readonly AppDbContext _context;
        public SectorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
