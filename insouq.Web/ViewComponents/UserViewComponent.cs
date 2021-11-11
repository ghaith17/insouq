using AutoMapper;
using insouq.EntityFramework;
using insouq.Shared.DTOS.UserDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace insouq.Web.ViewComponents
{
    [ViewComponent(Name = "User")]
    public class UserViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UserViewComponent(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userFromDb = await _db.Users.FirstOrDefaultAsync(u => u.Id.ToString() == claims.Value);
            var userDTO = _mapper.Map<UserDTO>(userFromDb);

            return View(userDTO);
        }
    }
}
