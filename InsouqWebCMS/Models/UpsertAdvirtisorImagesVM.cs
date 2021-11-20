using insouq.Models.StaticData;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class UpsertAdvirtisorImagesVM
    {
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile File1 { get; set; }
        public IFormFile File2 { get; set; }

        public AdvertisorImages AdvertisorImages { get; set; }
    }
}
