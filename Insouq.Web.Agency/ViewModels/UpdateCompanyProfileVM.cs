using insouq.Shared.DTOS.UserDTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insouq.Web.Agency.Models
{
    public class UpdateCompanyProfileVM
    {
        public CompanyProfileDTO CompanyProfile { get; set; }

        public int CategoryId { get; set; }

        public IFormFile TradeLicenseFile { get; set; }

        public IFormFile ProfilePicture { get; set; }
    }
}
