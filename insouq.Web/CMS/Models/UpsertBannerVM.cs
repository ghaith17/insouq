using insouq.Models.StaticData;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class UpsertBannerVM
    {
        public IFormFile File { get; set; }

        public Banner Banner { get; set; }
    }
}
