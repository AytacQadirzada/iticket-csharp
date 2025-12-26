using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Core.Enums;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Business.Service.Implementations
{
    public class VenueService :IVenueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public VenueService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(VenueRequestDto request)
        {
            //var entity = _mapper.Map<Venue>(request);

            //entity.Halls ??= new List<Hall>();

            //foreach (var hall in entity.Halls)
            //{
            //    hall.Venues = entity;
            //    hall.Sectors ??= new List<Sector>();

            //    foreach (var sector in hall.Sectors)
            //    {
            //        sector.Halls = hall;
            //    }
            //}

            var entity = new Venue
            {
                Address = request.Address,
                Mobile = request.Mobile,
                Name = request.Name,
                Phone = request.Phone,
                MapLat = request.MapLat,
                MapLng = request.MapLng,
                Halls = request.Halls?.Select(h => new Hall
                {
                    Name = h.Name,
                    Sectors = h.Sectors?.Select(s => new Sector
                    {
                        Name = s.Name,
                        RowCount = s.RowCount,
                        SeatCount = s.SeatCount,
                        Capacity = s.Capacity,
                        SectorClassification = s.SectorClassification
                    }).ToList()
                }).ToList()
            };

            await _unitOfWork.VenueRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }




        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.VenueRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Venues not found!");

            await _unitOfWork.VenueRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<VenueResponse>> GetAll()
        {
            var entities = await _unitOfWork.VenueRepository.GetAllAsync();

            if (entities is null)
                throw new Exception("Venues not found!");

            List<VenueResponse> result = _mapper.Map<List<VenueResponse>>(entities);
            return result;
        }

        public async Task<VenueResponse> Get(int id)
        {
            var entity = await _unitOfWork.VenueRepository.GetAsync(n => n.Id == id);

            if (entity is null)

                throw new Exception("Venues not found!");

            var result = _mapper.Map<VenueResponse>(entity);
            return result;
        }
    }
}
