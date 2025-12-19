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
    public class HallService : IHallService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public HallService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task Create(HallRequestDto request)
        {
            Hall entity = _mapper.Map<Hall>(request);
            await _unitOfWork.HallRepository.AddAsync(entity);
            








        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.HallRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Category not found!");

            await _unitOfWork.HallRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<HallResponse>> GetAll()
        {
            var entities = await _unitOfWork.HallRepository.GetAllAsync(includes: "Sectors");

            if (entities is null)
                throw new Exception("Categories not found!");

            List<HallResponse> result = _mapper.Map<List<HallResponse>>(entities);
            return result;
        }

        public async Task<HallResponse> Get(int id)
        {
            var entity = await _unitOfWork.HallRepository.GetAsync(n => n.Id == id, "Sectors");

            if (entity is null)
                throw new Exception("Category not found!");

            var result = _mapper.Map<HallResponse>(entity);
            return result;
        }
    }
}
