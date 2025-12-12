using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations
{
    public class HallRepository : Repository<Hall> , IHallRepository
    {
        private readonly AppDbContext _context;
        public HallRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
