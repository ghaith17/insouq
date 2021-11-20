using insouq.Models.StaticData;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class UpsertHIWVM
    {
        public IFormFile File { get; set; }
        public IFormFile File2 { get; set; }

        public HIW HIW { get; set; }

    }
}
