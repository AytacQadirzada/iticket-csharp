using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations
{
    public class SeatService : ISeatService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SeatService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(SeatRequestDto request)
        {
            Seat entity = _mapper.Map<Seat>(request);
            await _context.Seats.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Seats.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Seat not found!");

            _context.Seats.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SeatResponse>> GetAll()
        {
            var entities = await _context.Seats.ToListAsync();

            if (entities is null)
                throw new Exception("Seat not found!");

            List<SeatResponse> result = _mapper.Map<List<SeatResponse>>(entities);
            return result;
        }

        public async Task<SeatResponse> Get(int id)
        {
            var entity = await _context.Seats.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Seat not found!");

            var result = _mapper.Map<SeatResponse>(entity);
            return result;
        }
    }
}
