using AutoMapper;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.DTOS.CategoryDTOS;
using insouq.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public CategoryService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _db.Categories.Where(c => c.Status == 1).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return categoryDTO;
        }

        public async Task<CategoryDTO> GetByName(string name)
        {
            var category = await _db.Categories.Where(c => c.Status == 1).AsNoTracking().FirstOrDefaultAsync(c => c.Ar_Name == name || c.En_Name == name);

            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return categoryDTO;
        }

        public async Task<List<CategoryDTO>> GetByTypeId(int id)
        {
            var categories = await _db.Categories.Where(c => c.Status == 1).Where(s => s.TypeId == id).AsNoTracking().ToListAsync();

            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);

            return categoriesDTO;
        }

        public async Task<BaseResponse> Add(UpsertCategoryDTO model,string host)
        {
            var response = new BaseResponse();

            try
            {
                var category = new Category()
                {
                    Ar_Name = model.Ar_Name,
                    En_Name = model.En_Name,
                    TypeId = model.TypeId,
                    NumberOfAds = 0,
                    Status = 1
                };

                await _db.Categories.AddAsync(category);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server Error";
                return response;
            }
        }

        public async Task<BaseResponse> Update(UpsertCategoryDTO model, string host)
        {
            var response = new BaseResponse();

            try
            {
                var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == model.Id);

                category.Ar_Name = model.Ar_Name;
                category.En_Name = model.En_Name;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server Error";
                return response;
            }
        }

        public async Task<BaseResponse> Delete(int id)
        {
            var response = new BaseResponse();

            try
            {
                var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);

                category.Status = 3;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server Error";
                return response;
            }
        }

    }
}
