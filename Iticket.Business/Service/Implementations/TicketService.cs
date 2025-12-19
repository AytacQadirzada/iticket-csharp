using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations;

public class TicketService : ITicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    

    public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        

    }

    public async Task Create(TicketRequestDto request)
    {
        Ticket entity = _mapper.Map<Ticket>(request);
        await _unitOfWork.TicketRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
    }
    //public async Task BulkInsert(List<TicketRequestDto> request)
    //{
    //    List<Ticket> entities = _mapper.Map<List<Ticket>>(request);

    //    await _unitOfWork.TicketRepository.AddAsync(entities);
    //    await _unitOfWork.SaveAsync();
    //}


    public async Task Delete(int id)
    {
        var entity = await _unitOfWork.TicketRepository.GetAsync(n => n.Id == id);

        if (entity is null)
            throw new Exception("Ticket not found!");

        await _unitOfWork.TicketRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<TicketResponse>> GetAll()
    {
        var entities = await _unitOfWork.TicketRepository.GetAllAsync();

        if (entities is null)
            throw new Exception("Ticket not found!");

        List<TicketResponse> result = _mapper.Map<List<TicketResponse>>(entities);
        return result;
    }

    public async Task<TicketResponse> Get(int id)
    {
        var entity = await _unitOfWork.TicketRepository.GetAsync(n => n.Id == id);

        if (entity is null)
            throw new Exception("Ticket not found!");

        var result = _mapper.Map<TicketResponse>(entity);
        return result;
    }

    public Task BulkInsert(List<TicketRequestDto> request)
    {
        throw new NotImplementedException();
    }
}
