using insouq.Shared.DTOS;
using insouq.Shared.DTOS.CMS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface ISubTypeService
    {
        Task<SubTypeDTO> GetById(int id);
        Task<SubTypeDTO> GetByName(string name);
        //Task<BaseResponse> Add(AddCategoryDTO model);
        //Task<BaseResponse> Update(int id, AddCategoryDTO model);
        Task<List<SubTypeDTO>> GetBySubCategoryId(int id);
        Task<List<SubTypeDTO>> GetByCategoryId(int id);
        Task<List<SubTypeDTO>> GetByTypeId(int id);

        Task<BaseResponse> AddSubType(UpsertSubTypeDTO model);
        Task<BaseResponse> UpdateSubType(UpsertSubTypeDTO model);
        Task<BaseResponse> DeleteSubType(int Id);
    }
}
