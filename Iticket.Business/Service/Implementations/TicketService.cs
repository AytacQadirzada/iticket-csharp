using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations;

public class TicketService : ITicketService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TicketService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Create(TicketRequestDto request)
    {
        Ticket entity = _mapper.Map<Ticket>(request);
        await _context.Tickets.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task BulkInsert(List<TicketRequestDto> request)
    {
        List<Ticket> entities = _mapper.Map<List<Ticket>>(request);

        await _context.Tickets.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }


    public async Task Delete(int id)
    {
        var entity = await _context.Tickets.FirstOrDefaultAsync(n => n.Id == id);

        if (entity is null)
            throw new Exception("Ticket not found!");

        _context.Tickets.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TicketResponse>> GetAll()
    {
        var entities = await _context.Tickets.ToListAsync();

        if (entities is null)
            throw new Exception("Ticket not found!");

        List<TicketResponse> result = _mapper.Map<List<TicketResponse>>(entities);
        return result;
    }

    public async Task<TicketResponse> Get(int id)
    {
        var entity = await _context.Tickets.FirstOrDefaultAsync(n => n.Id == id);

        if (entity is null)
            throw new Exception("Ticket not found!");

        var result = _mapper.Map<TicketResponse>(entity);
        return result;
    }
}
