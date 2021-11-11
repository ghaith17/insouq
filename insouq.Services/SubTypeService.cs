using AutoMapper;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.CMS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class SubTypeService : ISubTypeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public SubTypeService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SubTypeDTO> GetById(int id)
        {
            var subType = await _db.SubTypes.Where(c => c.Status == 1).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            var subTypeDTO = _mapper.Map<SubTypeDTO>(subType);

            return subTypeDTO;
        }

        public async Task<SubTypeDTO> GetByName(string name)
        {
            var subType = await _db.SubTypes.Where(c => c.Status == 1).AsNoTracking().FirstOrDefaultAsync(c => c.Ar_Name == name || c.En_Name == name);

            var subTypeDTO = _mapper.Map<SubTypeDTO>(subType);

            return subTypeDTO;
        }

        public async Task<List<SubTypeDTO>> GetBySubCategoryId(int id)
        {
            var subTypes = await _db.SubTypes.Where(c => c.Status == 1).Where(s => s.SubCategoryId == id).AsNoTracking().ToListAsync();

            var subTypesDTO = _mapper.Map<List<SubTypeDTO>>(subTypes);

            return subTypesDTO;
        }

        public async Task<List<SubTypeDTO>> GetByCategoryId(int id)
        {
            var subTypes = await _db.SubTypes.Where(c => c.Status == 1).Include(s => s.SubCategory).Where(s => s.SubCategory.CategoryId == id)
                .AsNoTracking().ToListAsync();

            var subTypesDTO = _mapper.Map<List<SubTypeDTO>>(subTypes);

            return subTypesDTO;
        }

        public async Task<List<SubTypeDTO>> GetByTypeId(int id)
        {
            var subTypes = await _db.SubTypes.Where(c => c.Status == 1).Include(s => s.SubCategory).Include(s => s.SubCategory.Category)
                .Where(s => s.SubCategory.Category.TypeId == id)
                .AsNoTracking().ToListAsync();

            var subTypesDTO = _mapper.Map<List<SubTypeDTO>>(subTypes);

            return subTypesDTO;
        }

        public async Task<BaseResponse> AddSubType(UpsertSubTypeDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var subType = new SubType()
                {
                    SubCategoryId = model.SubCategoryId,
                    En_Name = model.En_Name,
                    Ar_Name = model.Ar_Name,
                    Status = 1
                };

                await _db.SubTypes.AddAsync(subType);

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

        public async Task<BaseResponse> UpdateSubType(UpsertSubTypeDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var subType = await _db.SubTypes.FirstOrDefaultAsync(s => s.Id == model.Id);

                if (subType == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                subType.En_Name = model.En_Name;
                subType.Ar_Name = model.Ar_Name;


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

        public async Task<BaseResponse> DeleteSubType(int Id)
        {
            var response = new BaseResponse();

            try
            {
                var subType = await _db.SubTypes.FirstOrDefaultAsync(s => s.Id == Id);

                if (subType == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                subType.Status = 3;

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
