using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations
{
    public class ProductEventService : IProductEventService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductEventService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(ProductEventRequestDto request)
        {
            ProductEvent entity = _mapper.Map<ProductEvent>(request);
            await _context.ProductEvents.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.ProductEvents.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("ProductEvent not found!");

            _context.ProductEvents.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductEventResponse>> GetAll()
        {
            var entities = await _context.ProductEvents.ToListAsync();

            if (entities is null)
                throw new Exception("ProductEvent not found!");

            List<ProductEventResponse> result = _mapper.Map<List<ProductEventResponse>>(entities);
            return result;
        }

        public async Task<ProductEventResponse> Get(int id)
        {
            var entity = await _context.ProductEvents.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("ProductEvent not found!");

            var result = _mapper.Map<ProductEventResponse>(entity);
            return result;
        }
    }
}
