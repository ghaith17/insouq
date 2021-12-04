using AutoMapper;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.DTOS.TypeDTOS;
using insouq.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class TypeService : ITypeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public TypeService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TypeDTO> GetById(int id)
        {
            var type = await _db.Types.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            var typeDTO = _mapper.Map<TypeDTO>(type);

            return typeDTO;
        }

        public async Task<TypeDTO> GetByIdWithCategories(int id)
        {
            var type = await _db.Types.Include(c => c.Categories).AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            var typeDTO = _mapper.Map<TypeDTO>(type);

            return typeDTO;
        }

        public async Task<TypeDTO> GetByName(string name)
        {
            var type = await _db.Types.AsNoTracking().FirstOrDefaultAsync(c => c.Ar_Name == name || c.En_Name == name);

            var typeDTO = _mapper.Map<TypeDTO>(type);

            return typeDTO;
        }

        public async Task<List<TypeDTO>> GetAll()
        {
            var categories = await _db.Types.AsNoTracking().ToListAsync();

            var categoriesDTO = _mapper.Map<List<TypeDTO>>(categories);

            return categoriesDTO;
        }

        public async Task<List<TypeDTO>> GetAllWithCategories()
        {
            var categories = await _db.Types.Include(c => c.Categories).AsNoTracking().ToListAsync();

            var categoriesDTO = _mapper.Map<List<TypeDTO>>(categories);

            return categoriesDTO;
        }

        public async Task<BaseResponse> Add(AddTypeDTO model, string host)
        {
            var response = new BaseResponse();

            try
            {
                var type = new Models.Type()
                {
                    Ar_Name = model.Ar_Name,
                    En_Name = model.En_Name,
                };

                await _db.Types.AddAsync(type);

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

        public async Task<BaseResponse> Update(int id, AddTypeDTO model, string host)
        {
            var response = new BaseResponse();

            try
            {
                var type = await _db.Types.FirstOrDefaultAsync(c => c.Id == id);

                type.Ar_Name = model.Ar_Name;
                type.En_Name = model.En_Name;

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
