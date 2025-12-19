using Iticket.Core.Interfaces;

namespace Iticket.Core;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IHallRepository HallRepository { get; }
    IProductEventRepository ProductEventRepository { get; }
    IProductRepository ProductRepository { get; }
    ISectorRepository SectorRepository { get; }
    ITicketRepository TicketRepository { get; }
    IVenuesRepository VenuesRepository { get; }
    IWishlistRepository WishlistRepository { get; }
    IBasketItemRepository BasketItemRepository { get; }
    IBasketRepository BasketRepository { get; }

    Task SaveAsync();
}
