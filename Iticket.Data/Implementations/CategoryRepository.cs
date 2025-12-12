using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations
{
    public class CategoryRepository : Repository<Category>,  ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
