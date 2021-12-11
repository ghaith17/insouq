using insouq.Shared.DTOS.UserDTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insouq.Web.Agency.Models
{
    public class UpdateProfileVM
    {
        public insouq.Models.Agent Agent { get; set; }
        public insouq.Models.Agency Agency { get; set; }
        public IFormFile CvFile { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public IFormFile IndustryFile { get; set; }
    }
}
