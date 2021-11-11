using insouq.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace insouq.Web.ViewComponents
{
    [ViewComponent(Name = "HeaderCategories")]
    public class HeaderCategoriesViewComponent : ViewComponent
    {
        private readonly ITypeService _typeService;

        public HeaderCategoriesViewComponent(ITypeService typeService)
        {
            _typeService = typeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var types = await _typeService.GetAllWithCategories();

            return View(types);
        }
    }
}
