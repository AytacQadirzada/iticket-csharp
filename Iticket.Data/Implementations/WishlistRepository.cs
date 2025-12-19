using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Data.Implementations
{
    public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
    {
        private readonly AppDbContext _context;
        public WishlistRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
