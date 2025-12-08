using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Iticket.Business.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITicketService _ticketService;
        public ProductService(AppDbContext context, IMapper mapper, ITicketService ticketService)
        {
            _context = context;
            _mapper = mapper;
            _ticketService = ticketService;
        }

        public async Task Create(ProductRequestDto request)
        {
            //var product = await _context.Products.Include(n => n.ProductEvents).ThenInclude(n => n.Venues).ThenInclude(n => n.Halls).FirstOrDefaultAsync(n => n.StartDate == request.StartDate);
            //if (product is not null)
            //{
            //    throw new BadHttpRequestException("Bu tarixde tedbir movcuddur");
            //}

            foreach (var pe in request.ProductEvents)
            {
                var productEvent = await _context.ProductEvents.Include(n => n.Hall).FirstOrDefaultAsync(n => n.EventDate == pe.EventDate && n.HallId == pe.HallId);

                if (productEvent is not null)
                    throw new BadHttpRequestException("Bu tarixde tedbir movcuddur");
            }

            //foreach (var pe in product.ProductEvents)
            //{
            //    pe.Venues.Halls.FirstOrDefault(n => n.Id == request.)
            //}


            Product entity = _mapper.Map<Product>(request);
           /// iki product event yaradilirdi biri requestin daxilinde gelen melumatlar ile mapper zamani biride bizim yaratdigimiz burda null yazdimki mapper zamani yaradilan productEvent silinsin.
            entity.ProductEvents = null; 
            List<TicketRequestDto> allTickets = new List<TicketRequestDto>();

            foreach (var productEvent in request.ProductEvents)
            {
                if (entity.ProductEvents is null)
                    entity.ProductEvents = new List<ProductEvent>();

                var hall = await _context.Halls.Include(n => n.Sectors).ThenInclude(n => n.Seats).Include(n => n.Venues).FirstOrDefaultAsync(n => n.Id == productEvent.HallId);
               
                var sectors = hall.Sectors;
                foreach(var sector in sectors)
                {
                    var seats = sector.Seats;
                    foreach(var seat in seats)
                    {
                        if (seat.Tickets is null)
                            seat.Tickets = new List<Ticket>();

                        seat.Tickets.Add(new Ticket
                        {
                            Price = productEvent.SectorPrices.FirstOrDefault(n => n.SectorId == sector.Id).Price,
                            Number = Guid.NewGuid().ToString(),
                        });
                        //TicketRequestDto ticketRequestDto = new
                        //    TicketRequestDto
                        //{
                        //    Price = productEvent.SectorPrices.FirstOrDefault(n => n.SectorId == sector.Id).Price,
                        //    Number = Guid.NewGuid().ToString(),
                        //    SeatId = seat.Id,

                        //};
                        //allTickets.Add(ticketRequestDto);
                        //await _ticketService.Create(ticketRequestDto);
                    }
                }

                //await _ticketService.BulkInsert(allTickets);

                ////
                ///

                //entity.ProductEvents.Add(new ProductEvent
                //{
                //    EventName = productEvent.EventName,
                //    EventDate = productEvent.EventDate,
                //    MinPrice = productEvent.MinPrice,
                //    VenuesId = venuesId,
                //    CreatedDate = DateTime.UtcNow.AddHours(4)
                //});

                ///
                ////
                ProductEvent productEvent1 = _mapper.Map<ProductEvent>(productEvent);

                entity.ProductEvents.Add(productEvent1);
            }

            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Product not found!");

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            var entities = await _context.Products.ToListAsync();

            if (entities is null)
                throw new Exception("Product not found!");

            List<ProductResponse> result = _mapper.Map<List<ProductResponse>>(entities);
            return result;
        }

        public async Task<ProductResponse> Get(int id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Product not found!");

            var result = _mapper.Map<ProductResponse>(entity);
            return result;
        }
    }
}
