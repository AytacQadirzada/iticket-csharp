using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations
{
    public class ProductEventService : IProductEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public ProductEventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task Create(ProductEventRequestDto request)
        {
            ProductEvent entity = _mapper.Map<ProductEvent>(request);
            await _unitOfWork.ProductEventRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.ProductEventRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("ProductEvent not found!");

            await _unitOfWork.ProductEventRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ProductEventResponse>> GetAll()
        {
            var entities = await _unitOfWork.ProductEventRepository.GetAllAsync(includes: "Halls");

            if (entities is null)
                throw new Exception("ProductEvent not found!");

            List<ProductEventResponse> result = _mapper.Map<List<ProductEventResponse>>(entities);
            return result;
        }

        public async Task<ProductEventResponse> Get(int id)
        {
            var entity = await _unitOfWork.ProductEventRepository.GetAsync(n => n.Id == id,"Halls");

            if (entity is null)
                throw new Exception("ProductEvent not found!");

            var result = _mapper.Map<ProductEventResponse>(entity);
            return result;
        }
    }
}
