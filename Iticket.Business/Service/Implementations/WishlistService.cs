using AutoMapper;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Implementations;

public class WishlistService : IWishlistService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public WishlistService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        


    }
    public async Task AddOrRemoveItem(string userId, int productId)
    {
        Wishlist wishlist = await _unitOfWork.WishlistRepository
            .GetAsync(w => w.UserId == userId, "Products");

        Product product = await _unitOfWork.ProductRepository
            .GetAsync(p => p.Id == productId);

        if (wishlist.Products == null)
            wishlist.Products = new List<Product>();

        var existingProduct = wishlist.Products
            .FirstOrDefault(p => p.Id == productId);

        if (existingProduct != null)
        {
            wishlist.Products.Remove(existingProduct);
        }
        else
        {
            wishlist.Products.Add(product);
        }

        await _unitOfWork.WishlistRepository.UpdateAsync(wishlist);
        await _unitOfWork.SaveAsync();
    }


    public async Task<WishlistResponse> Get(string userId)
    {
        Wishlist entity = await _unitOfWork.WishlistRepository.GetAsync(n => n.UserId == userId, "Products");
        WishlistResponse wishlist = _mapper.Map<WishlistResponse>(entity);
        return wishlist;

    }
}
