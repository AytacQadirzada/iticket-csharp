using Iticket.Core;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;
using Iticket.Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IUserRepository _userRepository;
    private ITicketRepository _ticketRepository;
    private ICategoryRepository _categoryRepository;
    private IHallRepository _hallRepository;
    private IProductEventRepository _productEventRepository;
    private IProductRepository _productRepository;
    private ISectorRepository _sectorRepository;
    private IVenueRepository _venueRepository;
    private IBasketRepository _basketRepository;
    private IBasketItemRepository _basketItemRepository;
    private IWishlistRepository _wishlistRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
    public IHallRepository HallRepository => _hallRepository ??= new HallRepository(_context);
    public IProductEventRepository ProductEventRepository => _productEventRepository ??= new ProductEventRepository(_context);
    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
    public ISectorRepository SectorRepository => _sectorRepository ??= new SectorRepository(_context);
    public ITicketRepository TicketRepository => _ticketRepository ??= new TicketRepository(_context);
    public IVenueRepository VenueRepository => _venueRepository ??= new VenueRepository(_context);
    public IBasketItemRepository BasketItemRepository => _basketItemRepository ??= new BasketItemRepository(_context);
    public IBasketRepository BasketRepository => _basketRepository ??= new BasketRepository(_context);
    public IWishlistRepository WishlistRepository => _wishlistRepository ??= new WishlistRepository(_context);

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
