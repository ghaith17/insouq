using AutoMapper;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public SubCategoryService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SubCategoryDTO> GetById(int id)
        {
            var subCategory = await _db.SubCategories.Where(c => c.Status == 1).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            var subCategoryDTO = _mapper.Map<SubCategoryDTO>(subCategory);

            return subCategoryDTO;
        }

        public async Task<SubCategoryDTO> GetByName(string name)
        {
            var subCategory = await _db.SubCategories.Where(c => c.Status == 1).AsNoTracking().FirstOrDefaultAsync(c => c.Ar_Name == name || c.En_Name == name);

            var subCategoryDTO = _mapper.Map<SubCategoryDTO>(subCategory);

            return subCategoryDTO;
        }

        public async Task<List<SubCategoryDTO>> GetByCategoryId(int id)
        {
            var subCategories = await _db.SubCategories.Where(c => c.Status == 1).Where(s => s.CategoryId == id).AsNoTracking().ToListAsync();

            var subCategoriesDTO = _mapper.Map<List<SubCategoryDTO>>(subCategories);

            return subCategoriesDTO;
        }

        public async Task<List<SubCategoryDTO>> GetByTypeId(int id)
        {
            var subCategories = await _db.SubCategories.Where(c => c.Status == 1).Include(s => s.Category).Where(s => s.Category.TypeId == id)
                .AsNoTracking().ToListAsync();

            var subCategoriesDTO = _mapper.Map<List<SubCategoryDTO>>(subCategories);

            return subCategoriesDTO;
        }

        public async Task<BaseResponse> AddSubCategory(SubCategoryDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var subCategory = new SubCategory()
                {
                    CategoryId = model.CategoryId,
                    En_Name = model.En_Name,
                    Ar_Name = model.Ar_Name,
                    Status = 1
                };

                await _db.SubCategories.AddAsync(subCategory);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> UpdateSubCategory(SubCategoryDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var subCategory = await _db.SubCategories.FirstOrDefaultAsync(s => s.Id == model.Id);

                if (subCategory == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                subCategory.En_Name = model.En_Name;
                subCategory.Ar_Name = model.Ar_Name;


                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> DeleteSubCategory(int Id)
        {
            var response = new BaseResponse();

            try
            {
                var subCategory = await _db.SubCategories.FirstOrDefaultAsync(s => s.Id == Id);

                if (subCategory == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                subCategory.Status = 3;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }
    }
}
