using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Interfaces
{
    public interface IWishlistService
    {
        public Task<WishlistResponse> Get(int id);
        public Task AddItem(int wishlistId, int productId);
        public Task RemoveItem(int wishlistId, int productId);
    }
}
