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
    public class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
    {
        private readonly AppDbContext _context;
        public BasketItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
