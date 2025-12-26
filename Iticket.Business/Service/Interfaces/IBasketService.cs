using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Interfaces;

public interface IBasketService
{
    public Task<BasketResponse> Get(string userId);
    public Task AddItem(AddItem item);
    public Task RemoveItem(string userId, int basketItemId);
}
