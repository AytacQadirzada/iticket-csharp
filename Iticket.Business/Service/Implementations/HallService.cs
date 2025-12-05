using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations
{
    public class HallService : IHallService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HallService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(HallRequestDto request)
        {
            Hall entity = _mapper.Map<Hall>(request);
            await _context.Halls.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Halls.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Category not found!");

            _context.Halls.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<HallResponse>> GetAll()
        {
            var entities = await _context.Halls.ToListAsync();

            if (entities is null)
                throw new Exception("Categories not found!");

            List<HallResponse> result = _mapper.Map<List<HallResponse>>(entities);
            return result;
        }

        public async Task<HallResponse> Get(int id)
        {
            var entity = await _context.Halls.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Category not found!");

            var result = _mapper.Map<HallResponse>(entity);
            return result;
        }
    }
}
