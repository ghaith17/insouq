using insouq.Shared.DTOS.UserDTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Web.ViewModels
{
    public class UpdateProfileVM
    {
        public UserDTO User { get; set; }
        public IFormFile CvFile { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public IFormFile IndustryFile { get; set; }
    }
}
