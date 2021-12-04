using insouq.Shared.DTOS.TypeDTOS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface ITypeService
    {
        Task<TypeDTO> GetById(int id);
        Task<TypeDTO> GetByIdWithCategories(int id);
        Task<TypeDTO> GetByName(string name);
        Task<List<TypeDTO>> GetAll();
        Task<List<TypeDTO>> GetAllWithCategories();
        Task<BaseResponse> Add(AddTypeDTO model, string host);
        Task<BaseResponse> Update(int id, AddTypeDTO model, string host);
    }
}
