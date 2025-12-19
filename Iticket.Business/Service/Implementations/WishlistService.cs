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
    public async Task AddItem(int wishlistId, int productId)
    {
        Wishlist wishlist = await _unitOfWork.WishlistRepository.GetAsync(n => n.Id == wishlistId, "Products");
        Product product = await _unitOfWork.ProductRepository.GetAsync(n => n.Id == productId);
        foreach (var item in wishlist.Products)
        {
            if (item.Id != product.Id) {
                wishlist.Products.Add(product);
            }

        }
        await _unitOfWork.WishlistRepository.UpdateAsync(wishlist);
    }

    public async Task<WishlistResponse> Get(int id)
    {
        Wishlist entity = await _unitOfWork.WishlistRepository.GetAsync(n => n.Id == id, "Products");
        WishlistResponse wishlist = _mapper.Map<WishlistResponse>(entity);
        return wishlist;

    }

    public async Task RemoveItem(int wishlistId, int productId)
    {
        Wishlist wishlist = await _unitOfWork.WishlistRepository.GetAsync(n => n.Id == wishlistId, "Products");
        Product product = await _unitOfWork.ProductRepository.GetAsync(n => n.Id == productId);
        foreach (var item in wishlist.Products)
        {
            if (item.Id == product.Id)
            {
                wishlist.Products.Remove(product);
            }

        }
        await _unitOfWork.WishlistRepository.UpdateAsync(wishlist);
    }
}
