using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations
{
    public class ProductEventRepository: Repository<ProductEvent>, IProductEventRepository
    {
        private readonly AppDbContext _context;
        public ProductEventRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
