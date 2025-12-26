using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Expection;
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
    public async Task AddItem(AddItem item)
    {
        Basket basket = await _unitOfWork.BasketRepository.GetAsync(n => n.UserId == item.UserId);
        List<Ticket> tickets = await _unitOfWork.TicketRepository.GetAllAsync(predicate: n => n.isBooked == false && n.ProductEventId == item.ProductEventId && n.SectorId == item.SectorId);
        if (basket.BasketItems is null)
            basket.BasketItems = new List<BasketItem>();
        if (item.TicketId is not null) { 
        Ticket ticket = await _unitOfWork.TicketRepository.GetAsync(n => n.Id.Equals(item.TicketId));
        var basketItem = new BasketItem()
        {
            Ticket = ticket,
            Price = ticket.Price
        };
        basket.BasketItems.Add(basketItem);
        }
        else
        {
            if (tickets.Count >= item.Quantity)
            {
                for (var i = 0; i < item.Quantity; i++)
                {
                    Ticket ticketItem = tickets.ElementAt(i);
                    var basketItem = new BasketItem() { 
                        Ticket = ticketItem,
                        Price = ticketItem.Price
                    };
                    basket.BasketItems.Add(basketItem);
                }
            }
            else
            {
                throw new NotFoundException("Daxil olunan sayda bilet yoxdur!");
            }
        }
        await _unitOfWork.BasketRepository.UpdateAsync(basket);

        await _unitOfWork.SaveAsync();

    }

    public async Task<BasketResponse> Get(string userId)
    {
        Basket basket = await _unitOfWork.BasketRepository.GetAsync(n => n.UserId == userId, "BasketItems","BasketItems.Ticket");
        BasketResponse response = _mapper.Map<BasketResponse>(basket);
        return response;
    }

    public async Task RemoveItem(string userId, int basketItemId)
    {
        Basket basket = await _unitOfWork.BasketRepository.GetAsync(n => n.UserId == userId, "BasketItems", "BasketItems.Ticket");

        var existingProduct = basket.BasketItems
            .FirstOrDefault(n => n.Id == basketItemId);
        if (existingProduct == null)
        {
            throw new NotFoundException("Bu bilet sebetde yoxdur!");
        }
        else
        {
            basket.BasketItems.Remove(existingProduct);
        }

        await _unitOfWork.BasketRepository.UpdateAsync(basket);
        await _unitOfWork.SaveAsync();

    }
}
