using Iticket.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Core
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IHallRepository HallRepository { get; }
        IProductEventRepository ProductEventRepository { get; }
        IProductRepository ProductRepository { get; }
        ISeatRepository SeatRepository { get; }
        ISectorRepository SectorRepository { get; }
        ITicketRepository TicketRepository { get; }
        IVenuesRepository VenuesRepository { get; }
    }
}
