using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations
{
    public class VenuesService :IVenuesService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VenuesService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(VenuesRequestDto request)
        {
            Venues entity = _mapper.Map<Venues>(request);
            await _context.Venues.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Venues.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Venues not found!");

            _context.Venues.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VenuesResponse>> GetAll()
        {
            var entities = await _context.Venues.ToListAsync();

            if (entities is null)
                throw new Exception("Venues not found!");

            List<VenuesResponse> result = _mapper.Map<List<VenuesResponse>>(entities);
            return result;
        }

        public async Task<VenuesResponse> Get(int id)
        {
            var entity = await _context.Venues.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Venues not found!");

            var result = _mapper.Map<VenuesResponse>(entity);
            return result;
        }
    }
}
