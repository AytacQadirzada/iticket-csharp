using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(ProductRequestDto request)
        {
            Product entity = _mapper.Map<Product>(request);

            foreach (var productEvent in request.ProductEvents)
            {
                if (entity.ProductEvents is null)
                    entity.ProductEvents = new List<ProductEvent>();

                var hall = await _context.Halls.Include(n => n.Sectors).ThenInclude(n => n.Seats).FirstOrDefaultAsync(n => n.Id == productEvent.HallId);
                Console.WriteLine(hall);
                Console.WriteLine(hall.ToString());

                entity.ProductEvents.Add(new ProductEvent
                {
                    EventName = productEvent.EventName,
                    EventDate = productEvent.EventDate,
                    MinPrice = productEvent.MinPrice,
                    CreatedDate = DateTime.UtcNow.AddHours(4)

                });
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
