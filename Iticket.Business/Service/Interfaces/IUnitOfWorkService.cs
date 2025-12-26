using Iticket.Business.Service.Implementations;
using Iticket.Core.Interfaces;
using Iticket.Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Interfaces
{
    public interface IUnitOfWorkService
    {
        IUserService UserService { get; }
        ICategoryService CategoryService { get; }
        IHallService HallService { get; }
        IProductEventService ProductEventService { get; }
        IProductService ProductService { get; }
        ISectorService SectorService { get; }
        ITicketService TicketService { get; }
        IVenueService VenueService { get; }
        IWishlistService WishlistService { get; }
        IBasketService BasketService { get; }
    }
}
