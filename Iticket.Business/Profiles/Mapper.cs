using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Core.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Iticket.Business.Profiles;

public class Mapper : Profile
{

    public Mapper()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryRequestDto, Category>();
        CreateMap<Hall, HallResponse>();
        CreateMap<HallRequestDto, Hall>();
        CreateMap<ProductEvent, ProductEventResponse>();
        CreateMap<ProductEventRequestDto, ProductEvent>();
        CreateMap<Product, ProductResponse>();
        CreateMap<ProductRequestDto, Product>();
        CreateMap<Sector, SectorResponse>();
        CreateMap<SectorRequestDto, Sector>();
        CreateMap<Ticket, TicketResponse>();
        CreateMap<TicketRequestDto, Ticket>();
        CreateMap<Venue, VenueResponse>();
        CreateMap<VenueRequestDto, Venue>();
        CreateMap<Wishlist, WishlistResponse>();
        CreateMap<Basket, BasketResponse>();
        CreateMap<BasketItem, BasketItemResponse>();



#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
