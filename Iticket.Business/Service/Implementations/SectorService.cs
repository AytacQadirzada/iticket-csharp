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
    public class SectorService : ISectorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public SectorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task Create(SectorRequestDto request)
        {
            Sector entity = _mapper.Map<Sector>(request);
            await _unitOfWork.SectorRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.SectorRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Sector not found!");

            await _unitOfWork.SectorRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<SectorResponse>> GetAll()
        {
            var entities = await _unitOfWork.SectorRepository.GetAllAsync();

            if (entities is null)
                throw new Exception("Sector not found!");

            List<SectorResponse> result = _mapper.Map<List<SectorResponse>>(entities);
            return result;
        }

        public async Task<SectorResponse> Get(int id)
        {
            var entity = await _unitOfWork.SectorRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Sector not found!");

            var result = _mapper.Map<SectorResponse>(entity);
            return result;
        }
    }
}
