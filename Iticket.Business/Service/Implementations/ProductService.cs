using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Iticket.Business.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        private readonly ITicketService _ticketService;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ITicketService ticketService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ticketService = ticketService;
            
        }
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task Create(ProductRequestDto request)
        {
            //var hallId = await _unitOfWork.SectorRepository.GetAsync( n => n.Id == request.ProductEvents.FirstOrDefault().SectorPrices.FirstOrDefault().SectorId).HallId;
            int sectorId = request.ProductEvents.SelectMany(pe => pe.SectorPrices).First(sp => sp.SectorId > 0).SectorId;
            Sector sectorEntity = await _unitOfWork.SectorRepository.GetAsync(n => n.Id == sectorId);
            int hallId = sectorEntity.HallId;
            
            //foreach (var pe in request.ProductEvents)
            //{
            //    var productEvent = await _unitOfWork.ProductEventRepository.GetAsync(n => n.EventDate == pe.EventDate && n.HallId == pe.HallId, "Hall");

            //    if (productEvent is not null)
            //        throw new BadHttpRequestException("Bu tarixde tedbir movcuddur");
            //}

            Product entity = _mapper.Map<Product>(request);
                    entity.ProductEvents = new List<ProductEvent>();

            foreach (var productEvent in request.ProductEvents)
            {

                ProductEvent productEvent1 = _mapper.Map<ProductEvent>(productEvent);

                Hall hall = await _unitOfWork.HallRepository.GetAsync(n => n.Id == hallId, "Sectors", "Venues" );
               
                var sectors = hall.Sectors;
                foreach (var sector in sectors)
                {
                    if (sector.SeatCount != 0 && sector.RowCount != 0)
                    {
                        for (int i = 0; i < sector.RowCount; i++)
                        {
                            for (int j = 0; j < sector.SeatCount; j++)
                            {
                                if (sector.Tickets is null)
                                {
                                    sector.Tickets = new List<Ticket>();
                                }
                                sector.Tickets.Add(
                                    new Ticket()
                                    {
                                        Price = productEvent.SectorPrices.FirstOrDefault(n => n.SectorId == sector.Id).Price,
                                        Number = Guid.NewGuid().ToString(),
                                        RowNumber = (i + 1).ToString(),
                                        ColumnNumber = (j + 1).ToString(),
                                        Sector = sector,
                                        ProductEvent = productEvent1
                                    });
                            }
                        }
                    }
                    else if(sector.Capacity != 0)
                    {
                        for(int i=0; i < sector.Capacity; i++)
                        {
                            if (sector.Tickets is null)
                            {
                                sector.Tickets = new List<Ticket>();
                            }
                            sector.Tickets.Add(
                                new Ticket()
                                {
                                    Price = productEvent.SectorPrices.FirstOrDefault(n => n.SectorId == sector.Id).Price,
                                    Number = Guid.NewGuid().ToString(),
                                    Sector = sector,
                                    ProductEvent = productEvent1
                                });
                        }
                    }
                }

                entity.ProductEvents.Add(productEvent1);
            }

            await _unitOfWork.ProductRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.ProductRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Product not found!");

            await _unitOfWork.ProductRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, ProductRequestDto request)
        {
            var entity = await _unitOfWork.ProductRepository.GetAsync(n => n.Id == id, "ProductEvents");

            if (entity is null)
                throw new Exception("Product not found!");

            foreach (var productEvent in request.ProductEvents)
            {
                //var productEventDb = entity.ProductEvents.FirstOrDefault(n => n.Id == productEvent.Id); /// id ile bagli problem var idni gore bilmire cunski requestde id yoxdur

                //if (productEventDb is null)
                //{
                //    var hall = await _unitOfWork.HallRepository.GetAsync(n => n.Id == productEvent.HallId, "Sectors.Seats", "Venues");

                //    var sectors = hall.Sectors;
                //    foreach (var sector in sectors)
                //    {
                //      if(sector.SeatCount != 0 && sector.RowCount != 0)
                //        {
                //           for(int i = 0; i < sector.RowCount; i++)
                //            {
                //                for (int j = 0; j < sector.SeatCount; j++)
                //                {
                //                    if (sector.Tickets is null)
                //                    {
                //                        sector.Tickets = new List<Ticket>();
                //                    }
                //                    sector.Tickets.Add(
                //                        new Ticket()
                //                        {
                //                            Price = productEvent.SectorPrices.FirstOrDefault(n => n.SectorId == sector.Id).Price,

                //                        });

                //                    //if (seat.Tickets is null)
                //                    //    seat.Tickets = new List<Ticket>();

                //                    //seat.Tickets.Add(new Ticket
                //                    //{
                //                    //    Price = productEvent.SectorPrices.FirstOrDefault(n => n.SectorId == sector.Id).Price,
                //                    //    Number = Guid.NewGuid().ToString(),
                //                    //});
                //                }
                //            }
                        //}
                    //}

                //    ProductEvent productEvent1 = _mapper.Map<ProductEvent>(productEvent);

                //    entity.ProductEvents.Add(productEvent1);
                //}
            }
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            var entities = await _unitOfWork.ProductRepository.GetAllAsync(includes: "Category");
            Console.WriteLine(entities);

            if (entities is null)
                throw new Exception("Product not found!");

            List<ProductResponse> result = _mapper.Map<List<ProductResponse>>(entities);
            Console.WriteLine(result);
            return result;
        }

        public async Task<ProductResponse> Get(int id)
        {
            var entity = await _unitOfWork.ProductRepository.GetAsync(n => n.Id == id, "Category");

            if (entity is null)
                throw new Exception("Product not found!");

            var result = _mapper.Map<ProductResponse>(entity);
            return result;
        }

        public async Task<List<ProductResponse>> GetFilter(FilterRequest request)
        {
            List<Product> products = new List<Product>();
            if(request.VenuesId == null && request.ProductEventDate == null)
            {
                products = await _unitOfWork.ProductRepository.GetAllAsync(n => n.MinPrice >= request.MinPrice && n.MinPrice <= request.MaxPrice);
            }
            else if(request.ProductEventDate == null)
            {
                List<Product> productEntity = await _unitOfWork.ProductRepository.GetAllAsync(n => n.MinPrice >= request.MinPrice && n.MinPrice <= request.MaxPrice, "ProductEvents", "ProductEvents.Tickets", "ProductEvents.Tickets.Sector", "ProductEvents.Tickets.Sector.Halls");
                foreach(var product in productEntity)
                {
                    foreach(var productEvent in product.ProductEvents)
                    {
                        if(productEvent.Tickets.FirstOrDefault().Sector.Halls.VenueId == request.VenuesId)
                        {
                            products.Add(product);
                        }
                    }
                }
            }
            else if (request.VenuesId == null)
            {
                products = await _unitOfWork.ProductRepository.GetAllAsync(n => n.MinPrice >= request.MinPrice && n.MinPrice <= request.MaxPrice && n.StartDate == request.ProductEventDate);
            }
            List<ProductResponse> response = _mapper.Map<List<ProductResponse>>(products);
            return response;
        }
        public async Task<ProductResponse> GetByTitle(string title) 
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(n => n.Title == title);
            var response = _mapper.Map<ProductResponse>(product);
            return response;
        }

        public async Task<List<ProductResponse>> GetByCategory(string slug)
        {
            List<Product> products = new List<Product>();
            var productsEntity = await _unitOfWork.ProductRepository.GetAllAsync(includes: "Category");
            foreach(var product in productsEntity)
            {
                if(product.Category.Slug == slug)
                {
                    products.Add(product);
                }
            }
            var response = _mapper.Map<List<ProductResponse>>(products);
            return response;
        }
    }

}
