using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class BussinesAdDTO : CommonAd
    {
        public List<IFormFile> Pictures { get; set; }

        public string MainPhoto { get; set; }

        [MaxLength(256)]
        public string OtherCategoryName { get; set; }

        public int? SubCategoryId { get; set; }

        public string OtherSubCategoryName { get; set; }

        public string PhoneNumber { get; set; }

        public double Price { get; set; }
    }
}
