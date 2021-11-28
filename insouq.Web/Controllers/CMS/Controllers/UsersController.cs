using insouq.Services.IServices.CMS;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Controllers
{
    [Authorize(Roles = StaticData.Admin_Role)]
    public class UsersController : Controller
    {
        private readonly ICMSUsersService _usersService;

        public UsersController(ICMSUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _usersService.GetAllUsers();

            return View(users);
        }

        #region API_CALLS

        [HttpDelete]
        public async Task<JsonResult> DeleteUser(int id)
        {
            var resposne = await _usersService.DeleteUser(id);

            return Json(resposne);
        }

        #endregion
    }
}
