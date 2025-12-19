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
    public class VenuesService :IVenuesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public VenuesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            



        }

        public async Task Create(VenuesRequestDto request)
        {
            Venues entity = _mapper.Map<Venues>(request);
            await _unitOfWork.VenuesRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.VenuesRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Venues not found!");

            await _unitOfWork.VenuesRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<VenuesResponse>> GetAll()
        {
            var entities = await _unitOfWork.VenuesRepository.GetAllAsync();

            if (entities is null)
                throw new Exception("Venues not found!");

            List<VenuesResponse> result = _mapper.Map<List<VenuesResponse>>(entities);
            return result;
        }

        public async Task<VenuesResponse> Get(int id)
        {
            var entity = await _unitOfWork.VenuesRepository.GetAsync(n => n.Id == id);

            if (entity is null)

                throw new Exception("Venues not found!");

            var result = _mapper.Map<VenuesResponse>(entity);
            return result;
        }
    }
}
