using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;

namespace Iticket.Data.Implementations;
    public class ProductRepository: Repository<Product> , IProductRepository
    {
    private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
        _context = context;
        }
    }

