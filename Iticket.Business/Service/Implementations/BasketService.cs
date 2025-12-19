using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Profiles;
using Iticket.Business.Service.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Implementations;

public class BasketService : IBasketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    

    public BasketService (IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }
    public async Task AddItem(int basketId, string ticketId)
    {
        var basket = await _unitOfWork.BasketRepository.GetAsync(n => n.Id == basketId);
        var ticket = await _unitOfWork.TicketRepository.GetAsync(n => n.Id.Equals(ticketId));

        foreach (var item in basket.BasketItems)
        {
        }
        var basketItem = new BasketItem()
        {
            Ticket = ticket,
            Count = 1,
            Price = ticket.Price
        };
        basket.BasketItems.Add(basketItem);

    }

    public Task AddItem(int basketId, int ticketId)
    {
        throw new NotImplementedException();
    }

    public Task<BasketResponse> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveItem(int basketId, int productId)
    {
        throw new NotImplementedException();
    }
}
