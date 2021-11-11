using insouq.Shared.DTOS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface ISubCategoryService
    {
        Task<SubCategoryDTO> GetById(int id);
        Task<SubCategoryDTO> GetByName(string name);
        //Task<BaseResponse> Add(AddCategoryDTO model);
        //Task<BaseResponse> Update(int id, AddCategoryDTO model);
        Task<List<SubCategoryDTO>> GetByCategoryId(int id);
        Task<List<SubCategoryDTO>> GetByTypeId(int id);

        Task<BaseResponse> AddSubCategory(SubCategoryDTO model);
        Task<BaseResponse> UpdateSubCategory(SubCategoryDTO model);
        Task<BaseResponse> DeleteSubCategory(int Id);
    }
}
