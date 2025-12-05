using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Iticket.Business.Service.Implementations
{
    public class CategoryService : ICategoryService     
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CategoryRequestDto request)
        {
            Category entity = _mapper.Map<Category>(request);
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Category not found!");

            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryResponse>> GetAll()
        {
            var entities = await _context.Categories.ToListAsync();

            if (entities is null)
                throw new Exception("Categories not found!");

            List<CategoryResponse> result = _mapper.Map<List<CategoryResponse>>(entities);
            return result;
        }

        public async Task<CategoryResponse> Get(int id)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(n => n.Id == id);

            if (entity is null)
                throw new Exception("Category not found!");

             var result = _mapper.Map<CategoryResponse>(entity);
            return result;
        }
    }
}
