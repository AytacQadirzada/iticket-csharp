using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations
{
    public class SectorService : ISectorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SectorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(SectorRequestDto request)
        {
            Sector entity = _mapper.Map<Sector>(request);
            await _context.Sectors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Sectors.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Sector not found!");

            _context.Sectors.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SectorResponse>> GetAll()
        {
            var entities = await _context.Sectors.ToListAsync();

            if (entities is null)
                throw new Exception("Sector not found!");

            List<SectorResponse> result = _mapper.Map<List<SectorResponse>>(entities);
            return result;
        }

        public async Task<SectorResponse> Get(int id)
        {
            var entity = await _context.Sectors.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Sector not found!");

            var result = _mapper.Map<SectorResponse>(entity);
            return result;
        }
    }
}
