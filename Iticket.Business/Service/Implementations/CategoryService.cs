using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace Iticket.Business.Service.Implementations
{
    public class CategoryService : ICategoryService     
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task Create(CategoryRequestDto request)
        {
            Category entity = _mapper.Map<Category>(request);
            await _unitOfWork.CategoryRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.CategoryRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Category not found!");

            await _unitOfWork.CategoryRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<CategoryResponse>> GetAll()
        {
            var entities = await _unitOfWork.CategoryRepository.GetAllAsync();

            if (entities is null)
                throw new Exception("CategoryRepository not found!");

            List<CategoryResponse> result = _mapper.Map<List<CategoryResponse>>(entities);
            return result;
        }

        public async Task<CategoryResponse> Get(int id)
        {
            var entity = await _unitOfWork.CategoryRepository.GetAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Category not found!");

             var result = _mapper.Map<CategoryResponse>(entity);
            return result;
        }
    }
}
