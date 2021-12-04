using insouq.Shared.DTOS.CategoryDTOS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> GetByName(string name);
        Task<BaseResponse> Add(UpsertCategoryDTO model, string host);
        Task<BaseResponse> Update(UpsertCategoryDTO model, string host);
        Task<List<CategoryDTO>> GetByTypeId(int id);
        Task<BaseResponse> Delete(int id);
    }
}
